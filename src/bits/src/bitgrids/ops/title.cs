//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitGrid
    {
        /// <summary>
        /// Defines a grid title suffixed with its signature
        /// </summary>
        /// <param name="label">Informative (?) text of some sort</param>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cel type representative</param>
        /// <typeparam name="W">The grid width type</typeparam>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string title<W,M,N,T>(string label, W w = default, M m = default, N n = default, T t = default)
            where W: unmanaged, ITypeNat
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => $"{label} {sigtext(w,m,n,t)}";

        /// <summary>
        /// Renders the grid signature as text
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cel type representative</param>
        /// <typeparam name="W"></typeparam>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string sigtext<W,M,N,T>(W w, M m = default, N n = default, T t = default)
            where W: unmanaged, ITypeNat
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => $"v{w}_{m}x{n}x{TypeIdentity.numeric<T>()}";
    }
}