//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static sys;

    /// <summary>
    /// Reserves 3 pages of memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size)]
    public struct PageBlock3
    {
        public const uint Size = PageCount*PageSize;

        public const uint PageCount = 3;

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
    }
}