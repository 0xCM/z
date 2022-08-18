//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// Tests whether a value is zero
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline)]
        public static bool zero<T>(T src)
            where T : unmanaged, INullary<T>
                => src.IsZero;

        /// <summary>
        /// Tests whether a value is zero
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline)]
        public static bool nonzero<T>(T src)
            where T : unmanaged, INullary<T>
                => src.IsNonZero;
    }
}