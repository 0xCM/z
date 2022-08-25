//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static sys;

    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static IndexPtr<T> ptr<T>(Index<T> src, uint pos)
            where T : unmanaged
                => new IndexPtr<T>(address(src).Pointer<T>(), src.Count, pos);

        /// <summary>
        /// Creates a representation over a specified generic pointer
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Ptr<T> ptr<T>(T* pSrc)
            where T : unmanaged
                =>  new Ptr<T>(pSrc);

        [MethodImpl(Inline)]
        public static unsafe T* ptr<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => (T*)AsPointer(ref edit(first(src)));

        [MethodImpl(Inline)]
        public static unsafe T* ptr<T>(Span<T> src)
            where T : unmanaged
                => (T*)AsPointer(ref edit(first(src)));
   }
}