//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MemAllocator : IBufferAllocator<ByteSize,MemorySegment>
    {
        public static MemAllocator alloc(ByteSize capacity)
            => new (capacity);

        NativeBuffer Buffer;

        public ByteSize Size {get;}

        uint Offset;

        MemoryAddress MaxAddress;

        internal MemAllocator(ByteSize size)
        {
            Size = size;
            Buffer = NativeBuffers.alloc(size);
            MaxAddress = Buffer.Address(size);
            Offset = 0;
        }

        public ByteSize Consumed
        {
            [MethodImpl(Inline)]
            get => Offset;
        }

        public ByteSize Remaining
        {
            [MethodImpl(Inline)]
            get => Size - Offset;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
        }

        public bool Alloc(ByteSize size, out MemorySegment dst)
        {
            var right = Buffer.Address(Offset + size);
            if(right > MaxAddress)
            {
                dst = MemorySegment.Empty;
                return false;
            }
            else
            {
                var left = Buffer.Address(Offset);
                dst = (left,right);
                Offset += (size + 1);
                return true;
            }
        }

        public void Clear()
        {
            Offset = 0;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}