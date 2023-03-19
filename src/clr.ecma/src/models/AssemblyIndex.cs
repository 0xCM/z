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

        public AssemblyMap Map()
            => new AssemblyMap(Seal());

        public AssemblyIndex Seal()
        {
            _Duplicates = Keysets.Values.Where(x => x.Count > 1).SelectMany(x => x).Array().Sort().Resequence();
            var keys = Keysets.Keys;
            var count = Keysets.Keys.Count;
            _Distinct = sys.alloc<Entry>(count);
            var i=0;
            iter(keys, key => _Distinct[i++] = Keysets[key].First());
            _Distinct.Sort();
            return this;
        }

        public void Include(EcmaFile ecma)
        {
            var reader = ecma.EcmaReader();
            var file = ecma.AssemblyFile();
            if(!reader.IsReferenceAssembly())
            {
                var entry = new Entry(inc(ref Seq), file.Path, file.Path.Size, reader.AssemblyKey());
                Lookup.TryAdd(file.Path, entry);
                lock(Keysets)
                {
                    if(Keysets.ContainsKey(entry.Key))
                        Keysets[entry.Key].Add(entry);
                    else
                        Keysets[entry.Key] = sys.hashset(entry);
                }
            }

        }

        public void Include(AssemblyFile src)
        {
            using var ecma = Ecma.file(src.Path);
            Include(ecma);
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
            public Entry(uint seq, FilePath path, ByteSize size, AssemblyKey key)
            {
                Seq = (uint)seq;
                Path = path;
                FileSize = size;
                Key = key;
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

            public EcmaMvid Mvid
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
}