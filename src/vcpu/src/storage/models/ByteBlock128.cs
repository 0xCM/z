//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = ByteBlock128;
    using api = Storage;
    using N = N128;

    /// <summary>
    /// Covers 128 bytes = 1024 bits of stack-allocated storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1)]
    public struct ByteBlock128
    {
        public const ushort Size = 128;

        public static N N => default;

        ByteBlock64 A;

        ByteBlock64 B;

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

       public static B Empty => default;
   }
}