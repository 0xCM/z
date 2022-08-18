//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct gcells
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Presents a 128-bit vector as a 128-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Cell128 cell128<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Cell128>(src);

        /// <summary>
        /// Presents a 256-bit vector as a 256-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Cell256 cell256<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Cell256>(src);

        /// <summary>
        /// Presents a 512-bit vector as a 512-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Cell512 cell512<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Cell512>(src);
    }
}