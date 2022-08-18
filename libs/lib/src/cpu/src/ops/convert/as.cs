//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct cpu
    {
        /// <summary>
        /// Reinterprets a vector over S-cells as a vector over T-cells
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell type representative</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector128<T> @as<S,T>(in Vector128<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => ref core.@as<Vector128<S>,Vector128<T>>(x);

        /// <summary>
        /// Reinterprets a vector over S-cells as a vector over T-cells
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell type representative</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector256<T> @as<S,T>(in Vector256<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => ref core.@as<Vector256<S>,Vector256<T>>(x);
    }
}