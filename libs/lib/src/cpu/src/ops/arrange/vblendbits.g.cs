//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblendbits<T>(Vector128<T> x, Vector128<T> y, Vector128<T> mask)
            where T : unmanaged
                => gcpu.vxor(x, gcpu.vand(gcpu.vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblendbits<T>(Vector256<T> x, Vector256<T> y, Vector256<T> mask)
            where T : unmanaged
                => gcpu.vxor(x, gcpu.vand(gcpu.vxor(x,y), mask));
    }
}