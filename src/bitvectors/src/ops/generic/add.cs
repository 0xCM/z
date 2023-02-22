//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;
    using static sys;

    partial class BitVectors
    {
        /// <summary>
        /// Computes the sum of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        /// <remarks>Follows https://github.com/chfast/intx/include/intx/int128.hpp</remarks>
        [MethodImpl(Inline)]
        public static BitVector128<T> add<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
        {
            var sum = vadd(v64u(x.State), v64u(y.State));
            bit carry = x.Lo > vcell(sum,0);
            return generic<T>(vadd(sum, vbroadcast(w128, (ulong)carry)));
        }
    }
}