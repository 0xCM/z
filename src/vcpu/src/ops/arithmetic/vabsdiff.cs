//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu 
    {
        /// <summary>
        /// Computes v[i] = |a[i] - b[i]|
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(Inline), Abs]
        public static Vector128<byte> vabsdiff(Vector128<byte> a, Vector128<byte> b)
            => vor(vsubs(a, b), vsubs(b, a));

        /// <summary>
        /// Computes v[i] = |a[i] - b[i]|
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(Inline), Abs]
        public static Vector128<ushort> vabsdiff(Vector128<ushort> a, Vector128<ushort> b)
            => vor(vsubs(a, b), vsubs(b, a));

        /// <summary>
        /// Computes v[i] = |a[i] - b[i]|
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(Inline), Abs]
        public static Vector256<byte> vabsdiff(Vector256<byte> a, Vector256<byte> b)
            => vor(vsubs(a, b), vsubs(b, a));

        /// <summary>
        /// Computes v[i] = |a[i] - b[i]|
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(Inline), Abs]
        public static Vector256<ushort> vabsdiff(Vector256<ushort> a, Vector256<ushort> b)
            => vor(vsubs(a, b), vsubs(b, a));
    }
}