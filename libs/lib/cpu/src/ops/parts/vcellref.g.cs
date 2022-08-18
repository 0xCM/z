//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Returns a reference to an index-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T vcellref<T>(in Vector128<T> src, byte index)
            where T : unmanaged
                => ref core.add(vfirst(src), index);

        /// <summary>
        /// Returns a reference to an index-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T vcellref<T>(in Vector256<T> src, byte index)
            where T : unmanaged
                => ref core.add(vfirst(src), index);

        /// <summary>
        /// Returns a reference to an index-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T vcellref<T>(in Vector512<T> src, byte index)
            where T : unmanaged
                => ref core.add(vfirst(src), index);
    }
}