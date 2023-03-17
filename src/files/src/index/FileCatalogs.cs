//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Commands;

    public class FileCatalogs : Channeled<FileCatalogs>
    {
        public record struct Entry : ISequential<Entry>, IComparable<Entry>
        {
            [Render(8)]
            public uint Seq;

            [Render(48)]
            public Hash128 ContentHash;

            [Render(16)]
            public Hash32 LocationHash;     

            [Render(1)]
            public FilePath Location;

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Location.Hash;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => ContentHash.Lo == 0 && ContentHash.Hi == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => ContentHash.Lo != 0 || ContentHash.Hi != 0;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public int CompareTo(Entry src)
                => Location.CompareTo(src.Location);

            public bool Equals(Entry src)
                => Location.Equals(src.Location) && ContentHash == src.ContentHash && LocationHash == src.LocationHash;

            uint ISequential.Seq 
                { get => Seq; set => Seq = value; }

            public static Entry Empty => new();
        }

        public static Entry entry(MemoryFile src)
        {
            var hash = FS.hash(src);
            return new Entry{
                Location = src.Path,
                ContentHash = hash.FileHash.ContentHash,
                LocationHash = hash.FileHash.LocationHash,
            };
        }

        public static Entry entry(FilePath src)
        {
            var hash = FS.hash(src);
            return new Entry{
                Location = src,
                ContentHash = hash.FileHash.ContentHash,
                LocationHash = hash.FileHash.LocationHash,
            };
        }

        public void Run(CatalogFiles cmd)
        {
            var name = FS.identifier(cmd.Source);
            var dst = cmd.Target + FS.file(name, FileKind.Csv);
            var running =  Channel.Running($"Adding files from {cmd.Source} to catalog");
            var counter = 0u;
            var paths = bag<FilePath>();
            var rows = bag<ListedFile>();
            void Accept(FilePath file)
            {
                paths.Add(file);
                rows.Add(new ListedFile{
                    Seq = counter++,
                    Size = file.Size.Kb,
                    Path = file,
                    CreateTS = file.Info.CreationTime,
                    UpdateTS = file.Info.LastWriteTime,
                    Attributes = file.Info.Attributes
                });                
            }

            enumerate(Channel, cmd.Source, cmd.Match, Accept);

            Channel.TableEmit(rows.ToSeq().Sort().Resequence(), dst);
            Channel.Ran(running, counter);
        }

        static void enumerate(IWfChannel channel, FolderPath input, ReadOnlySeq<FileExt> match, Action<FilePath> dst, bool pll = true)
        {
            var src = match.IsEmpty ? FS.enumerate(input,"*.*", true) : FS.enumerate(input, true, match.Storage);
            var counter = 0u;
            var flow = channel.Running($"Searching {input}");
            string msg()
                => $"Collected {counter} files";

            iter(src, file => {
                dst(file);
                counter++;
                if(counter % 1024 == 0)
                    channel.Babble(msg());
            }, pll);
            channel.Ran(flow, $"Found {counter} files from {input}");
        }

        Entry Steps(FilePath src)
        {
            var info = FS.info(src);
            var e = Entry.Empty;
            if(info.Length != 0)
            {
                using var file = MemoryFiles.map(src);
                e = entry(file);
            }
            return e;            
        }

        public ExecToken<ReadOnlySeq<Entry>> Index(IDbArchive src, IDbArchive dst)
        {
            var flow = Channel.Running($"Indexing {src.Root}");
            var index = dst.Path(FS.file("index", FileKind.Csv));
            var buffer = bag<Entry>();
            iter(src.Enumerate(true), path => {
                var entry = Steps(path);
                if(entry.IsNonEmpty)
                    buffer.Add(entry);
                }, true);
            var entries = buffer.Array().Resequence();
            Channel.TableEmit(entries, index);
            return (Channel.Ran(flow,$"Indexed {entries.Length} files"), entries.ToReadOnlySeq());
        }
    }
}