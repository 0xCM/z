//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Atomically increments a value in-place
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static long inc(ref long src)
            => Interlocked.Increment(ref src);

        /// <summary>
        /// Atomically increments a value in-place
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static int inc(ref int src)
            => Interlocked.Increment(ref src);

        [MethodImpl(Inline)]
        public static ref uint inc(ref uint dst)
        {
            inc(ref @as<int>(dst));
            return ref dst;
        }
    }
}