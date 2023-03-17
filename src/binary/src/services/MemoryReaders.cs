//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class MemoryReaders
    {
        public unsafe abstract class MemoryReader<R>
        {
            protected readonly MemoryAddress BaseAddress;
            
            protected readonly MemoryAddress LastAddress;

            protected readonly ByteSize Size;

            protected uint Position;

            [MethodImpl(Inline)]
            protected MemoryReader(MemoryAddress src, ByteSize size, uint offset = 0)
            {
                BaseAddress = src;
                Position = offset;
                Size = size;
                LastAddress = BaseAddress + size;
            }

            [MethodImpl(Inline)]
            protected void Advance(ByteSize size)
            {
                Position += size;
            }


            protected ReadOnlySpan<byte> Bytes
            {
                [MethodImpl(Inline)]
                get => cover(BaseAddress.Pointer<byte>(), Size);
            }


            [MethodImpl(Inline)]
            protected T* Pointer<T>()
                where T : unmanaged
                    => (BaseAddress + Position).Pointer<T>();


            [MethodImpl(Inline)]
            public T Read<T>()
                where T : unmanaged
            {
                var value = *Pointer<T>();
                Advance(size<T>());
                return value;
            }

            [MethodImpl(Inline)]
            public byte Read(N1 n)
                => Read<byte>();

            [MethodImpl(Inline)]
            public ushort Read(N2 n)
                => Read<ushort>();

            [MethodImpl(Inline)]
            public uint Read(N4 n)
                => Read<uint>();

            [MethodImpl(Inline)]
            public ulong Read(N8 n)
                => Read<ulong>();

        }

        public sealed class MemoryReader : MemoryReader<MemoryReader>
        {
            public MemoryReader(MemoryAddress @base, ByteSize size, uint offset = 0)
                : base(@base, size, offset)
            {

            }


        }
        
    }
}