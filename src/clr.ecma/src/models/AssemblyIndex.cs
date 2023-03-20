//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    public class AssemblyIndex : Channeled<AssemblyIndex>
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
            _Distinct.Sort().Resequence();
            return this;
        }

        public ReadOnlySeq<Entry> Report()
        {
            var buffer = bag<Entry>();
            iter(Keys(), k => buffer.AddRange(Keysets[k]), true);
            return buffer.Array().Sort().Resequence();
        }

        public void Report(IDbArchive dst)
        {
            Channel.TableEmit(Report(), dst.Path("assemlyindex", FileKind.Csv));
            Channel.TableEmit(Distinct(), dst.Path("assemblyindex.distinct", FileKind.Csv));
        }

        public void CopyTo(IDbArchive dst)
        {
            var src = Distinct();
            iter(src, entry => {
                var path = dst.Scoped($"{entry.Name}/{entry.Version}").Path(entry.Path.FileName);
                try
                {
                    FS.copy(entry.Path, path);                
                    Channel.Row($"{entry.Path} -> {path}");
                }
                catch(Exception e)
                {
                    Channel.Warn(e.Message);
                }
            });
        }

        public void Include(EcmaFile ecma)
        {
            var reader = ecma.EcmaReader();
            var file = ecma.AssemblyFile();
            if(!reader.IsReferenceAssembly())
            {
                var entry = new Entry(inc(ref Seq), file.Path, file.Path.Size, reader.ReadTargetFramework(), reader.AssemblyKey());
                if(Lookup.TryAdd(file.Path, entry))
                {
                    lock(Keysets)
                    {
                        if(Keysets.ContainsKey(entry.Key))
                            Keysets[entry.Key].Add(entry);
                        else
                            Keysets[entry.Key] = sys.hashset(entry);
                    }                
                }
            }

            if(Seq != 0 && Seq % 100 == 0)
                Channel.Babble($"Indexed {Seq} assemblies");
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

        public record struct Entry : IDataType<Entry>, ISequential<Entry>
        {
            [Render(8)]
            public uint Seq;

            [Render(64)]
            public readonly @string Name;

            [Render(16)]
            public readonly AssemblyVersion Version;

            [Render(36)]
            public readonly @string TargetFramework;

            [Render(48)]
            public readonly EcmaMvid Mvid;

            [Render(12)]
            public readonly Kb FileSize;

            [Render(1)]
            public readonly FilePath Path;

            [MethodImpl(Inline)]
            public Entry(uint seq, FilePath path, ByteSize size, string framework, AssemblyKey key)
            {
                Seq = (uint)seq;
                Path = path;
                TargetFramework = framework;
                FileSize = size.Kb;
                Version = key.Version;
                Name = key.Name;
                Mvid = key.Mvid;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsEmpty;
            }

            public AssemblyKey Key 
            {
                [MethodImpl(Inline)]
                get => new AssemblyKey(Name,Version,Mvid);
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Key.Hash | Path.Hash;
            }
                    
            public AssemblyFile File 
                => new AssemblyFile(Path, Key);

            uint ISequential.Seq { get => Seq; set => Seq = value; }

            public override int GetHashCode()
                => Hash;

            public int CompareTo(Entry src)
            {
                var result = Name.CompareTo(src.Name);
                if(result == 0)
                {
                    result = Version.CompareTo(src.Version);
                    if(result == 0)
                    {
                        result = TargetFramework.CompareTo(src.TargetFramework); 
                        if(result == 0)
                            result = Mvid.CompareTo(src.Mvid);
                    }
                }
                return result;
            }
        }
    }
}