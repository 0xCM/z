//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = ByteBlock47;
    using api = Storage;

    /// <summary>
    /// Covers 47 bytes = 256 bits of stack-allocated storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct ByteBlock47
    {
        public const ushort Size = 47;

        public static N47 N => default;

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

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<byte> src)
            => api.block<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator B(Span<byte> src)
            => api.block<B>(src);

      public static B Empty => default;
    }
}