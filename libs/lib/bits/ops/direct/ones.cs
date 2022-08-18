//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Produces a sequence of n enabled bits, starting from index 0 and extending to index n - 1
        /// </summary>
        /// <typeparam name="n">The enabled bit count</typeparam>
        [MethodImpl(Inline),Op]
        public static ulong ones(int n)
            => blsi(Pow2.pow((byte)n));
    }
}