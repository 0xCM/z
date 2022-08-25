//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBits
    {
        byte Width {get;}
    }

    public interface IBits<T> : IBits
        where T : unmanaged
    {
        T Value {get;}
    }

    public interface IBits<N,T> : IBits<T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        byte IBits.Width
            => Typed.nat8u<N>();
    }
}