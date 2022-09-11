//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBitDensity 
    {
        uint D {get;}   
    }

    public interface IBitDensity<D> : IBitDensity
        where D : unmanaged, ITypeNat
    {
        D d => default;
    }
}