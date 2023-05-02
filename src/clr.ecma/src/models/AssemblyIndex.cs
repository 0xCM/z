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

        readonly Dictionary<VersionedName,Entry> _VersionedEntries = new();

        public static AssemblyIndex create(IWfChannel channel, IDbArchive src)
        {
            var index = new AssemblyIndex(channel,src);
            index.Calc(src);
            var dst = index.Seal();
            return index;
        }

        public static AssemblyIndex create(IWfChannel channel, AssemblyFiles src)
        {
            var index = new AssemblyIndex(channel,src.Source);
            index.Calc(src);
            var dst = index.Seal();            
            return index;
        }

        readonly IWfChannel Channel;
        
        public readonly IDbArchive Source;

        AssemblyIndex(IWfChannel channel, IDbArchive src)
        {
            Channel = channel;
            Source = src;
        }

        void Calc(AssemblyFiles src)
        {
            var counter = 0u;
            iter(src, file => {
                using var ecma = Ecma.file(file.Path);
                Include(ecma);
                if(++counter % 100 == 0)
                    Channel.Babble($"Indexed {counter} assemblies");
                
            }, true);

        }

        void Calc(IDbArchive src)
        {
            var files = ModuleArchives.modules(src.Root).AssemblyFiles();
            var counter = 0u;
            iter(files, file => {
                using var ecma = Ecma.file(file.Path);
                Include(ecma);
                if(++counter % 100 == 0)
                    Channel.Babble($"Indexed {counter} assemblies");                
            }, true);
        }

        AssemblyIndex Seal()
        {
            _Duplicates = Keysets.Values.Where(x => x.Count > 1).SelectMany(x => x).Array().Sort().Resequence();
            var keys = Keysets.Keys;
            var count = Keysets.Keys.Count;
            _Distinct = sys.alloc<Entry>(count);
            var i=0;
            iter(keys, key => _Distinct[i++] = Keysets[key].First());
            _Distinct.Sort().Resequence();
            iter(_Distinct, entry => _VersionedEntries.TryAdd(entry.Name, entry));
            return this;
        }

        public ReadOnlySeq<Entry> Report()
        {
            var buffer = bag<Entry>();
            iter(Keys(), k => buffer.AddRange(Keysets[k]), true);
            return buffer.Array().Sort().Resequence();
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

        void Include(EcmaFile ecma)
        {
            var reader = ecma.EcmaReader();
            var file = ecma.AssemblyFile();
            if(!reader.IsReferenceAssembly())
            {
                var entry = new Entry(inc(ref Seq), file.Path, file.Path.Size, reader.ReadTargetFramework(), reader.AssemblyKey(), md5(ecma.ImageData));
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
        }

        public ReadOnlySeq<Entry> Duplicates()
            => _Duplicates;

        public ReadOnlySeq<Entry> Distinct()
            => _Distinct;

        public ICollection<Entry> Entries() 
            => Lookup.Values;

        public ICollection<AssemblyKey> Keys()
            => Keysets.Keys;
        
        public IReadOnlyDictionary<VersionedName,Entry> VersionedEntries()
            => _VersionedEntries;
            
        public IEnumerable<Entry> Entries(AssemblyKey key)
            => Keysets[key];

        public record struct Entry : IDataType<Entry>, ISequential<Entry>
        {
            [Render(8)]
            public uint Seq;

            [Render(64)]
            public readonly VersionedName Name;

            [Render(16)]
            public readonly AssemblyVersion Version;

            [Render(36)]
            public readonly @string TargetFramework;

            [Render(48)]
            public readonly EcmaMvid Mvid;

            [Render(12)]
            public readonly Kb FileSize;

            [Render(48)]
            public readonly Hash128 ContentHash;

            [Render(1)]
            public readonly FilePath Path;

            [MethodImpl(Inline)]
            public Entry(uint seq, FilePath path, ByteSize size, string framework, AssemblyKey key, Hash128 hash)
            {
                Seq = (uint)seq;
                Path = path;
                TargetFramework = framework;
                FileSize = size.Kb;
                Version = key.Version;
                Name = key.AssemblyName;
                Mvid = key.Mvid;
                ContentHash = hash;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsEmpty;
            }

            public AssemblyKey Key 
            {
                [MethodImpl(Inline)]
                get => new AssemblyKey(Name, Version, TargetFramework, Mvid);
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Key.Hash | Path.Hash;
            }
                    
            public AssemblyFile File 
                => new AssemblyFile(Path, Name);

            uint ISequential.Seq { get => Seq; set => Seq = value; }

            public override int GetHashCode()
                => Hash;

            public int CompareTo(Entry src)
                => Key.CompareTo(src.Key);
        }
    }
}