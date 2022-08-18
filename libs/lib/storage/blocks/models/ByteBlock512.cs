//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using B = ByteBlock512;
    using api = Storage;

    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1), DataTypeAttributeD("block<n:512,t:u8>")]
    [DataWidth(Size*8,Size*8)]
    public struct ByteBlock512 : IStorageBlock<B>
    {
        public const ushort Size = 512;

        ByteBlock256 A;

        ByteBlock256 B;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Bytes);
        }

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public ref T Cell<T>(uint index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static B Empty => default;
   }
}