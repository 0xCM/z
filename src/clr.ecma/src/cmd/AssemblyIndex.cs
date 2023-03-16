//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    public class AssemblyIndex
    {
        static uint Seq;

        Seq<Entry> _Duplicates = new();

        Seq<Entry> _Distinct = new();

        readonly ConcurrentDictionary<FilePath,Entry> Lookup = new();

        readonly Dictionary<AssemblyKey,HashSet<Entry>> Keysets = new();

        static Entry entry(AssemblyFile src)
        {
            using var ecma = Ecma.file(src.Path);
            var reader = ecma.EcmaReader();
            var module = reader.ReadModuleRow().View(reader);
            return new Entry(inc(ref Seq), src.Path, src.Path.Size, src.AssemblyName.SimpleName, src.Version, module.Mvid);
        }

        public AssemblyIndex Seal()
        {
            _Duplicates = Keysets.Values.Where(x => x.Count > 1).SelectMany(x => x).Array().Sort().Resequence();
            var keys = Keysets.Keys;
            var count = Keysets.Keys.Count;
            _Distinct = sys.alloc<Entry>(count);
            var i=0;
            iter(keys, key => _Distinct[i++] = Keysets[key].First());
            return this;
        }

        public void Include(AssemblyFile src)
        {
            var e = entry(src);
            Lookup.TryAdd(src.Path, e);
            lock(Keysets)
            {
                if(Keysets.ContainsKey(e.Key))
                    Keysets[e.Key].Add(e);
                else
                    Keysets[e.Key] = sys.hashset(e);
            }
        }
        
        public void Include(IEnumerable<AssemblyFile> src)
        {
            iter(src, Include, true);
        }

        public ReadOnlySeq<Entry> Duplicates()
            => _Duplicates;

        public ReadOnlySeq<Entry> Distinct()
            => _Distinct;

        public ICollection<Entry> Entries() 
            => Lookup.Values;

        public ICollection<AssemblyKey> Keys()
            => Keysets.Keys;

        public IEnumerable<Entry> Entries(AssemblyKey key)
            => Keysets[key];

        public record struct Entry : IComparable<Entry>, ISequential<Entry>
        {
            public uint Seq;

            public readonly FilePath Path;

            public readonly ByteSize FileSize;

            public readonly AssemblyKey Key;

            [MethodImpl(Inline)]
            public Entry(uint seq, FilePath path, ByteSize size, @string name, AssemblyVersion version, Guid mvid)
            {
                Seq = (uint)seq;
                Path = path;
                FileSize = size;
                Key = new (name,version,mvid);
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Key.Hash | Path.Hash;
            }
            
            public @string Name
            {
                [MethodImpl(Inline)]
                get => Key.Name;
            }

            public AssemblyVersion Version
            {
                [MethodImpl(Inline)]
                get => Key.Version;
            }

            public Guid Mvid
            {
                [MethodImpl(Inline)]
                get => Key.Mvid;
            }

            public @string Identifier
            {
                [MethodImpl(Inline)]
                get => Key.Identifier;
            }

            uint ISequential.Seq { get => Seq; set => Seq = value; }

            public override int GetHashCode()
                => Hash;

            public int CompareTo(Entry src)
            {
                var result = Key.CompareTo(src.Key);
                if(result == 0)
                {
                    result = FileSize.CompareTo(src.FileSize);
                    if(result == 0)
                        result = Path.CompareTo(src.Path);
                }
                return result;
            }
        }
    }

    partial class XTend
    {
        public static AssemblyIndex CreateAssemblyIndex(this IEnumerable<AssemblyFile> src)
        {
            var dst = new AssemblyIndex();
            dst.Include(src);
            return dst.Seal();
        }
    }
}