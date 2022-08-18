//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using B = ByteBlock50;
    using api = Storage;

    /// <summary>
    /// Covers 50 bytes = 256 bits of stack-allocated storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1)]
    public struct ByteBlock50 : IStorageBlock<B>
    {
        public const ushort Size = 50;

        public static N50 N => default;

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

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => api.empty(this);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !api.empty(this);
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