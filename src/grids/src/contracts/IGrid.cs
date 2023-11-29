//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IGrid
{
    uint M {get;}

    uint N {get;}

    GridDim Dim
        => (M,N);

    GridSpec Spec {get;}
}

[Free]
public interface IGrid<T> : IGrid
    where T : unmanaged
{
    Span<T> Cells {get;}

    Span<T> this[uint row] {get;}

    ref T this[uint row, uint col] {get;}

    GridSpec IGrid.Spec
        => grids.spec<T>(M,N);
}

[Free]
public interface IGrid<F,T> : IGrid<T>
    where T : unmanaged
    where F : unmanaged, IGrid<F,T>
{

}

[Free]
public interface IGrid<F,N,T> : IGrid<F,T>
    where N : unmanaged, ITypeNat
    where T : unmanaged
    where F : unmanaged, IGrid<F,N,T>
{
    uint IGrid.M
        => Typed.nat32u<N>();

    uint IGrid.N
        => Typed.nat32u<N>();
}

[Free]
public interface IGrid<F,M,N,T> : IGrid<F,T>
    where N : unmanaged, ITypeNat
    where M : unmanaged, ITypeNat
    where T : unmanaged
    where F : unmanaged, IGrid<F,M,N,T>
{
    uint IGrid.M
        => Typed.nat32u<M>();

    uint IGrid.N
        => Typed.nat32u<N>();
}
