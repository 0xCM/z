//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    /// <summary>
    /// Computes dimension information for a blocked grid predicated on parametric types
    /// </summary>
    /// <param name="w">The block width representative</param>
    /// <param name="m">The row count representative</param>
    /// <param name="n">The col count representative</param>
    /// <param name="t">The cell type representative</param>
    /// <typeparam name="W">The block width</typeparam>
    /// <typeparam name="M">The row type</typeparam>
    /// <typeparam name="N">The col type</typeparam>
    /// <typeparam name="T">The cell type</typeparam>
    public static GridDim<W,M,N,T> dim<W,M,N,T>(W w = default, M m = default, N n = default, T t = default)
        where W : unmanaged, IDataWidth
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => default;
}
