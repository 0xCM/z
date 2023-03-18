//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class MemoryReaders
    {
        public static MemoryReader reader(MemoryAddress @base, ByteSize size, uint offset = 0)
            => new MemoryReader(@base, size,offset);
            
        public unsafe abstract class MemoryReader<R>
        {
            protected readonly MemoryAddress BaseAddress;
            
            protected readonly MemoryAddress LastAddress;

            protected readonly ByteSize Size;

            protected uint Position;

            protected readonly uint LastPosition;

            [MethodImpl(Inline)]
            protected MemoryReader(MemoryAddress src, ByteSize size, uint offset = 0)
            {
                BaseAddress = src;
                Position = offset;
                Size = size;
                LastAddress = BaseAddress + size;
                LastPosition = size;
            }

            [MethodImpl(Inline)]
            protected void Advance(ByteSize size)
            {
                Position += size;
            }

            protected ReadOnlySpan<byte> Bytes()
                => cover(BaseAddress.Pointer<byte>(), Size);


            [MethodImpl(Inline)]
            protected ReadOnlySpan<byte> Bytes(uint offset)
                => slice(Bytes(), offset);

            [MethodImpl(Inline)]
            protected T* Pointer<T>()
                where T : unmanaged
                    => (BaseAddress + Position).Pointer<T>();

            [MethodImpl(Inline)]
            protected uint Remaining()
                => Position <= LastPosition ? LastPosition - Position : 0;

            [MethodImpl(Inline)]
            public T Read<T>()
                where T : unmanaged
            {
                var value = *Pointer<T>();
                Advance(size<T>());
                return value;
            }

            public ReadOnlySpan<byte> Read(uint requested)
            {
                var length = Position + requested < LastPosition ? requested : Remaining();
                var data = slice(Bytes(),Position, length);
                Advance(length);
                return data;
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