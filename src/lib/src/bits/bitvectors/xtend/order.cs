//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Computes the smallest integer n > 1 such that v^n = identity
        /// </summary>
        [MethodImpl(Inline)]
        public static int Order(this BitVector8 src)
            => BitVectors.ord(src);
    }
}