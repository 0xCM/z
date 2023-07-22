//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// 8x16u -> 8x8u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target vector width</param>
        /// <param name="t">A target component type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector128<ushort> x)
            => vpack128x8u(x, default);

        /// <summary>
        /// 16x16u -> 16x8u
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector256<ushort> src)
            => vpackus(vlo(src), vhi(src));

        /// <summary>
        /// 16x16i -> 16x8u
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector256<short> src)
            => v8u(vpackss(vlo(src), vhi(src)));

        /// <summary>
        /// 8x32u -> 8x8u (a scalar vector)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector256<uint> src)
            => vpack128x8u(vpack128x16u(src));

        /// <summary>
        /// (8x16i,8x16i) -> 16x8u
        /// </summary>
        /// <param name="x">The first source vector</param>
        /// <param name="y">The second source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector128<short> x, Vector128<short> y)
            => vpackus(x,y);

        /// <summary>
        /// (8x16u,8x16u) -> 16x8u
        /// </summary>
        /// <param name="a">The first source vector</param>
        /// <param name="b">The second source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector128<ushort> a, Vector128<ushort> b)
            => vpackus(a,b);

        /// <summary>
        /// (8x32u, 8x32u) -> 16x8u
        /// </summary>
        /// <param name="a">The first source vector</param>
        /// <param name="b">The second source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector256<uint> a, Vector256<uint> b)
            => vpack128x8u(vpack256x16u(a, b));

        /// <summary>
        /// (4x32u,4x32u,4x32u,4x32u) -> 16x8u
        /// </summary>
        /// <param name="a">The first source vector</param>
        /// <param name="b">The second source vector</param>
        /// <param name="c">The third source vector</param>
        /// <param name="d">The fourth source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vpack128x8u(Vector128<uint> a, Vector128<uint> b, Vector128<uint> c, Vector128<uint> d)
            => vpack128x8u(vpack128x16u(a, b), vpack128x16u(c, d));
    }
}