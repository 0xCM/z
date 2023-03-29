//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XSb
    {
        /// <summary>
        /// Applies a sequence of transpositions to a blocked container
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock128<T> Swap<T>(this SpanBlock128<T> src, params Swap[] swaps)
            where T : unmanaged
        {
             if(swaps == null || swaps.Length == 0)
                return src;

             src.Storage.Swap(swaps);
             return src;
        }

        /// <summary>
        /// Applies a sequence of transpositions to a blocked container
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock256<T> Swap<T>(this SpanBlock256<T> src, params Swap[] swaps)
            where T : unmanaged
        {
             if(swaps == null || swaps.Length == 0)
                return src;

             src.Storage.Swap(swaps);
             return src;
        }
    }
}