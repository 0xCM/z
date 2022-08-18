//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct vpack
    {
        /// <summary>
        /// 32x8i -> 32x16i
        /// src[i] -> lo[i], i = 1,..,15
        /// src[i] -> hi[i], i = 16,..,31
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="x0">The first target vector</param>
        /// <param name="x1">The second target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<short> vinflate512x16i(Vector256<sbyte> src)
            => (vlo256x16i(src), vhi256x16i(src));

        /// <summary>
        /// 32x8w -> 32x16i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="lo">The first target vector</param>
        /// <param name="hi">The second target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<short> vinflate512x16i(Vector256<byte> src)
            => (vlo256x16i(src), vhi256x16i(src));
    }
}