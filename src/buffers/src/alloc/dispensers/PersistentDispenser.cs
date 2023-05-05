//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe sealed class PersistentDispenser : Dispenser<PersistentDispenser>, IPersistentDispenser
    {
        public static ByteSize DefaultCapacity => new Gb(1);

        static IDbArchive DefaultStorage => AppSettings.Default.EnvDb().Scoped("dat");

        readonly Dictionary<long,PersistentAllocator> Allocators = new();

        readonly IDbArchive StorageRoot;

        readonly ByteSize Capacity;

        readonly ByteSize SegmentSize;

        internal PersistentDispenser(ByteSize? capacity = null, ByteSize? segsize = null, IDbArchive? root = null, FilePath? first = null)
            : base(false)
        {
            Capacity = capacity ?? DefaultCapacity;
            SegmentSize = segsize ?? Pow2.T18;
            StorageRoot = root ??(DefaultStorage);
            var name = first != null ? first.Value.FileName : FS.file(Guid.NewGuid().ToString(), FS.ext("dat"));
            var path = first != null ? first.Value : StorageRoot.Path(name);
            AddAllocator(path);
        }

        PersistentAllocator AddAllocator(FilePath path)
        {
            var i = next();
            Allocators[i] = new PersistentAllocator(MemDb.open(path, Capacity), SegmentSize);
            return Allocators[i];
        }

        PersistentMemory Dispense(asci32 name, ByteSize size, out PersistentAllocator _alloc)
        {
            var dst = PersistentMemory.Empty;
            if(size > Capacity)
                sys.@throw($"ALlocation capacity of {Capacity} exceeded by {size - Capacity}");
                
            lock(Locker)
            {
                _alloc = Allocators[Seq];
                if(!_alloc.Alloc(name, size, out dst))
                {
                    var file = Guid.NewGuid().ToString();
                    _alloc = AddAllocator(StorageRoot.Path(FS.file(file, FS.ext("dat"))));
                    _alloc.Alloc(size, out dst);
                }

            }
            return dst;
        }

        public PersistentMemory Dispense(asci32 name, ByteSize size)
            => Dispense(name, size, out _);

        [MethodImpl(Inline)]
        public PersistentMemory Dispense(ByteSize size)
            => Dispense(Guid.NewGuid().ToString(), size);

        [MethodImpl(Inline)]
        PersistentMemory Dispense(ByteSize size, out PersistentAllocator alloc)
            => Dispense(Guid.NewGuid().ToString(), size, out alloc);

        protected override void Dispose()
        {
            
        }

        [MethodImpl(Inline)]
        public MemorySeg Memory(ByteSize size)
        {
            var mem = Dispense(size);
            return new MemorySeg(mem.BaseAddress, mem.Size);
        }

        public MemorySeg Memory(ReadOnlySpan<byte> src)
        {
            var memory = Dispense(src.Length, out var alloc);
            alloc.Store(memory.Token, src);
            return new MemorySeg(memory.BaseAddress, memory.Size);            
        }

        public StringRef String(ReadOnlySpan<char> src)
        {
            var length = (uint)src.Length;
            var size = length*2;
            var mem = Dispense(size, out var alloc);
            alloc.Store(mem.Token, src);
            return new StringRef(mem.BaseAddress, length);
        }

        [MethodImpl(Inline)]
        public StringRef String(string src)
            => String(span(src));

        public SourceText SourceText(string src)
        {
            var s = String(src);
            return new SourceText(s.Address, s.ByteCount);
        }

        public SourceText SourceText(ReadOnlySpan<string> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x));
            return SourceText(dst.Emit());
        }

        public Label Label(ReadOnlySpan<char> src)
        {
            var content = src;
            var length = src.Length;
            if(length > byte.MaxValue)
                content = slice(src,0,byte.MaxValue);            
            var s = String(content);
            return new Label(s.Address, (byte)s.ByteCount);
        }

        public Label Label(string src)
            => Label(span(src));
    }
}