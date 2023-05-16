//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class MemDb : IMemDb
    {
        public static PersistentAllocator allocator(IMemDb db, ByteSize? @default = null)
            => new PersistentAllocator(db, @default);
 
        public static MemDb open(FilePath store)
            => open(store,0);

        public static MemDb open(FilePath store, ByteSize capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity));

        public static MemDb open(FilePath store, Gb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static MemDb open(FilePath store, Mb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        readonly MemoryFile DbMap;

        public readonly MemoryFileInfo Description;

        uint Offset;

        public ulong Capacity
        {
            [MethodImpl(Inline)]
            get => DbMap.FileSize;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => DbMap.FileSize;
        }

        public MemoryAddress BaseAddress 
        {
            [MethodImpl(Inline)]
            get => DbMap.BaseAddress;
        }

        public MemDb(FilePath path, ByteSize size)
        {
            var spec = MemoryFileSpec.init(path.CreateParentIfMissing()).WithCapacity(size).WithOpenOrCreateMode().WithReadWriteAccess();
            spec.Stream = true;
            DbMap = new MemoryFile(spec);
            Description = DbMap.Description;
        }

        public void Store<T>(AllocToken token, ReadOnlySpan<T> src)
            where T : unmanaged
        {
            Demand.lteq((ulong)src.Length * size<T>(), token.Size);
            DbMap.Stream.Seek(token.Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(recover<T,byte>(src));
            DbMap.Flush();
        }

        public AllocToken Store<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var size = sys.size<T>()*(uint)src.Length;
            var offset = Offset;
            var next = (uint)(Offset + size);
            if(next > Size)
                return AllocToken.Empty;
            DbMap.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(recover<T,byte>(src));
            Offset = next;
            DbMap.Flush();
            return new AllocToken(DbMap.BaseAddress, offset, size);
        }

        public AllocToken Store(ReadOnlySpan<byte> src)
        {
            var size = (uint)src.Length;
            var offset = Offset;
            var next = (uint)(Offset + src.Length);
            if(next > Size)
                return AllocToken.Empty;
            DbMap.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(src);
            Offset = next;
            DbMap.Flush();
            return new AllocToken(DbMap.BaseAddress, offset, size);
        }

        public AllocToken Reserve(ByteSize size)
        {
            var offset = Offset;
            var next = (uint)(Offset + size);
            if(next > Size)
                return AllocToken.Empty;
            Offset = next;
            return new AllocToken(DbMap.BaseAddress, offset, size);
        }

        [MethodImpl(Inline)]
        public AllocToken Token(uint offset, ByteSize size)
            => new (BaseAddress,offset,size);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Load(AllocToken token)
            => DbMap.View(token.Offset, token.Size);

        [MethodImpl(Inline)]
        public Span<byte> Edit(AllocToken token)
            => DbMap.Edit(token.Offset, token.Size);

        MemoryFileInfo IMemDb.Description
            => Description;

        [MethodImpl(Inline)]
        public static uint NextSeq(DbObjectKind kind)
            => sys.inc(ref ObjSeqSource[kind]);

        public static Index<MemoryFileInfo> Allocated()
            => Opened.Values.Map(x => x.Description);

        static readonly ConcurrentDictionary<FilePath,MemDb> Opened = new();

        const byte ObjTypeCount = 24;

        static Index<DbObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);
    }
}