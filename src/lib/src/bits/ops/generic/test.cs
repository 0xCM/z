//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        [MethodImpl(Inline)]
        public static bit test<T,I>(T src, I index)
            where T : unmanaged
            where I : unmanaged
                => bit.gtest(src, index);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, false otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit, Closures(AllNumeric)]
        public static bit test<T>(T src, byte pos)
            where T : unmanaged
                => bit.gtest(src,pos);
    }
}