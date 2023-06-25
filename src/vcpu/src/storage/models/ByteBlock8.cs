//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = ByteBlock8;
    using api = Storage;

    [StructLayout(LayoutKind.Sequential, Pack=1), DataWidth(Size*8,Size*8)]
    public struct ByteBlock8
    {
        public const ushort Size = 8;

        public static N8 N => default;

        ByteBlock7 A;

        ByteBlock1 B;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline), UnscopedRef]
            get => bytes(this);
        }

        public ref byte First
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref first(Bytes);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), UnscopedRef]
            get => api.empty(this);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !api.empty(this);
        }

        public ref byte this[int index]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(First,index);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(First,index);
        }

        [MethodImpl(Inline), UnscopedRef]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline), UnscopedRef]
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline), UnscopedRef]
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
        public static implicit operator B(ulong src)
            => @as<ulong,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(B src)
            => @as<B,ulong>(src);

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<byte> src)
            => api.block<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator B(Span<byte> src)
            => api.block<B>(src);

        public static B Empty => default;
    }
}