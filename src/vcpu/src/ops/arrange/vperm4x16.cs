//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Permutes the lower four elements of the source vector with the lo mask and the upper four elements with the hi mask
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="lo">The lo spec</param>
        /// <param name="hi">The hi spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vperm4x16(Vector128<short> src, [Imm] Perm4L lo, [Imm] Perm4L hi)
            => vpermhi4x16(vpermlo4x16(src,lo),hi);

        /// <summary>
        /// Shuffles the first four elements of the source vector with the lo mask and the last four elements with the hi mask
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="lo">The lo mask</param>
        /// <param name="hi">The hi mask</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vperm4x16(Vector128<ushort> src, [Imm] Perm4L lo, [Imm] Perm4L hi)
            => vpermhi4x16(vpermlo4x16(src,lo),hi);
    }
}