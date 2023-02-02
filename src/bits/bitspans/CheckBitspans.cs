//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ClaimValidator;

    public readonly struct CheckBitSpans : IClaimValidator
    {
        /// <summary>
        /// Asserts the equality of two bitspans
        /// </summary>
        /// <param name="a">The left bitspan</param>
        /// <param name="b">The right bitspan</param>
        [MethodImpl(Inline)]
        public static void eq(in BitSpan32 a, in BitSpan32 b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.require(a==b, ClaimKind.Eq);

        /// <summary>
        /// Asserts the equality of two bitspans
        /// </summary>
        /// <param name="a">The left bitspan</param>
        /// <param name="b">The right bitspan</param>
        [MethodImpl(Inline)]
        public static void eq(in BitSpan a, in BitSpan b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => api.require(a==b, ClaimKind.Eq);
    }
}