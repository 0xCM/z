//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        /// <summary>
        ///  This operator is equivalent to select, but is implemented xor(b, and(xor(b,a),  mask))
        /// </summary>
        /// <param name="mask">Mask that identifies which of the two source operands to choose a given bit</param>
        /// <param name="a">The first operand, a bit from which is chosen if the corresponding mask bit is enabled</param>
        /// <param name="b">The second operand, a bit from which is chosen if the corresponding mask bit is disabled</param>
        /// <typeparam name="T">The primal type</typeparam>
        /// <remarks>Code generation for this is good; type-specific specializations exist for convenience. Algorithm
        /// taken from https://graphics.stanford.edu/~seander/bithacks.html</remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T blend<T>(T a, T b, T mask)
            where T : unmanaged
                => xor(a, and(xor(a,b), mask));
    }
}