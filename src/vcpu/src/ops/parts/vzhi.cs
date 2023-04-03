//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static vcpu;

    partial class vgcpu
    {
        /// <summary>
        /// __m128i _mm_move_epi64 (__m128i a) MOVQ xmm, xmm
        /// Clears the high 64 bits of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vzhi<T>(Vector128<T> src)
            where T : unmanaged
                => MoveScalar(v64u(src)).As<ulong,T>();
    }
}