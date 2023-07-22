//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;

    partial class vcpu
    {
        /// <summary>
        /// Transposes a 4x4 matrix of floats, adapted from MSVC intrinsic headers
        /// </summary>
        /// <param name="row0">The first row</param>
        /// <param name="row1">The second row</param>
        /// <param name="row2">The third row</param>
        /// <param name="row3">The fourth row</param>
        [MethodImpl(Inline), Op]
        public static void vtranspose(ref Vector128<float> row0, ref Vector128<float> row1, ref Vector128<float> row2, ref Vector128<float> row3)
        {
            var tmp0 = Shuffle(row0,row1, 0x44);
            var tmp2 = Shuffle(row0, row1, 0xEE);
            var tmp1 = Shuffle(row2, row3, 0x44);
            var tmp3 = Shuffle(row2,row3, 0xEE);
            row0 = Shuffle(tmp0,tmp1, 0x88);
            row1 = Shuffle(tmp0,tmp1, 0xDD);
            row2 = Shuffle(tmp2,tmp3, 0x88);
            row3 = Shuffle(tmp2, tmp3, 0xDD);
        }

        /// <summary>
        /// Transposes a 4x4 matrix of unsigned integers, adapted from MSVC intrinsic headers
        /// </summary>
        /// <param name="row0">The first row</param>
        /// <param name="row1">The second row</param>
        /// <param name="row2">The third row</param>
        /// <param name="row3">The fourth row</param>
        [MethodImpl(Inline), Op]
        public static void vtranspose(ref Vector128<uint> row0, ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
        {
            var tmp0 = Shuffle(v32f(row0),v32f(row1), 0x44);
            var tmp2 = Shuffle(v32f(row0), v32f(row1), 0xEE);
            var tmp1 = Shuffle(v32f(row2), v32f(row3), 0x44);
            var tmp3 = Shuffle(v32f(row2),v32f(row3), 0xEE);
            row0 = v32u(Shuffle(tmp0,tmp1, 0x88));
            row1 = v32u(Shuffle(tmp0,tmp1, 0xDD));
            row2 = v32u(Shuffle(tmp2,tmp3, 0x88));
            row3 = v32u(Shuffle(tmp2, tmp3, 0xDD));
        }

        // [MethodImpl(Inline), Op]
        // public static Vector512<uint> vtranspose(Vector512<uint> src)
        // {
        //     var x = Shuffle(v32f(src.Lo), v32f(src.Hi), 0x44);
        //     var y = Shuffle(v32f(src.Lo), v32f(src.Hi), 0xEE);
        //     return(v32u(Shuffle(x,y, 0x88)), v32u(Shuffle(x,y, 0xDD)));
        // }
    }
}