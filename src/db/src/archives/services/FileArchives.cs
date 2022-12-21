//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class FileArchives : AppService<FileArchives>
    {
        public record struct Entry : ISequential<Entry>, IComparable<Entry>
        {
            [Render(8)]
            public uint Seq;

            [Render(48)]
            public Hash128 ContentHash;

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
                => Location.Equals(src.Location) && ContentHash == src.ContentHash;

            uint ISequential.Seq 
                { get => Seq; set => Seq = value; }
        }

        public void Injest(IDbArchive src, IDbArchive dst)
        {
            var flow = Channel.Running($"Injesting files from {src.Root}");
            var index = dst.Path(FS.file($"index.{Env.pid()}.{timestamp()}", FileKind.Csv));
            var buffer = bag<Entry>();
            iter(src.Enumerate("*.*"), path => buffer.Add(new Entry{
                Location = path,
                ContentHash = FS.hash(path)
            }), true);            

            var entries = buffer.Array().Resequence();
            Channel.TableEmit(entries, index);
            Channel.Ran(flow,$"Injested {entries.Length} files");
        }
    }

}