//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = ByteBlock1;
    using api = Storage;

    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct ByteBlock1 : IStorageBlock<B>
    {
        public static N1 N => default;

        public const ushort Size = 1;

        byte A;

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

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
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

        public string Format(bool prespec, bool uppercase)
            => api.format(this, Chars.Space, prespec, uppercase);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(byte src)
            => @as<uint,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(B src)
            => @as<B,byte>(src);

        public static B Empty => default;
    }
}