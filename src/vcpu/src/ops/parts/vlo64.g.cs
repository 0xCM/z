//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vgcpu
    {
        /// <summary>
        /// Extracts the lower 64 source bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong vlo64<T>(Vector128<T> src)
            where T : unmanaged
                => vcpu.vcell(vcpu.v64u(src),0);

        // /// <summary>
        // /// Extracts the lower 256-bit vector from the source
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <typeparam name="T">The cell type</typeparam>
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static Vector256<T> vlo256<T>(Vector512<T> src)
        //     where T : unmanaged
        //         => src.Lo;
    }
}