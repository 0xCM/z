//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class FileArchives : Channeled<FileArchives>
    {
        public record struct Entry : ISequential<Entry>, IComparable<Entry>
        {
            [Render(8)]
            public uint Seq;

            [Render(56)]
            public FileHash FileHash;

            [Render(1)]
            public FilePath Location;

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Location.Hash;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public int CompareTo(Entry src)
                => Location.CompareTo(src.Location);

            public bool Equals(Entry src)
                => Location.Equals(src.Location) && FileHash == src.FileHash;

            uint ISequential.Seq 
                { get => Seq; set => Seq = value; }
        }

        public static Entry entry(FilePath src)
        {
            var hash = FS.hash(src);
            return new Entry{
                Location = src,
                FileHash = hash.FileHash,
            };
        }

        public void Injest(IDbArchive src, IDbArchive dst)
        {
            var flow = Channel.Running($"Injesting files from {src.Root}");
            var index = dst.Path(FS.file($"index.{ProcessId.current()}.{timestamp()}", FileKind.Csv));
            var buffer = bag<Entry>();
            iter(src.Enumerate(true), path => buffer.Add(entry(path)), true);
            var entries = buffer.Array().Resequence();
            Channel.TableEmit(entries, index);
            Channel.Ran(flow,$"Injested {entries.Length} files");
        }
    }
}