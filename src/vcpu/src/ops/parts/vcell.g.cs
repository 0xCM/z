//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vgcpu
    {
        /// <summary>
        /// Returns an index-identified cell value
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector128<T> src, byte index)
            where T : unmanaged
                => src.GetElement(index);

        /// <summary>
        /// Specifies the value of an index-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vcell<T>(Vector128<T> src, byte index, T value)
            where T : unmanaged
                => src.WithElement(index, value);

        /// <summary>
        /// Specifies the value of an index-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vcell<T>(Vector256<T> src, byte index, T value)
            where T : unmanaged
                => src.WithElement(index, value);

        /// <summary>
        /// Returns a reference to an index-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector256<T> src, byte index)
            where T : unmanaged
                => src.GetElement(index);

        /// <summary>
        /// Returns a naturally-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell selector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector256<T> src, N0 index)
            where T : unmanaged
                => src.GetElement(0);

        /// <summary>
        /// Returns a naturally-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell selector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector256<T> src, N1 index)
            where T : unmanaged
                => src.GetElement(1);

        /// <summary>
        /// Returns a naturally-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell selector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector256<T> src, N2 index)
            where T : unmanaged
                => src.GetElement(2);

        /// <summary>
        /// Returns a naturally-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell selector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector256<T> src, N3 index)
            where T : unmanaged
                => src.GetElement(3);

        /// <summary>
        /// Returns a naturally-identified cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The cell selector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T vcell<T>(Vector256<T> src, N4 index)
            where T : unmanaged
                => src.GetElement(4);

        /// <summary>
        /// Extracts a T-indexed component from a vector obtained by converting the S-vector to a T-vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The index of the component to extract</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static T vcell<S,T>(Vector128<S> src, byte index)
            where S : unmanaged
            where T : unmanaged
                => src.As<S,T>().GetElement(index);
    }
}