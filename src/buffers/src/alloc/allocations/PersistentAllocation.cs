//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe sealed class PersistentAllocation : Allocation<byte>
    {
        // public static PersistentAllocation alloc(IMemDb src, ByteSize size)
        //     => new(MemDb.memory(src, size));

        public override MemoryAddress BaseAddress => Memory.BaseAddress;

        public override ByteSize Size => Memory.Size;

        protected override Span<byte> Data 
            => sys.cover(Memory.BaseAddress.Pointer<byte>(), Memory.Size);

        readonly PersistentMemory Memory;

        PersistentAllocation(PersistentMemory src)
        {
            Memory = src;
        }
        protected override void Dispose()
        {
            
        }
    }
}