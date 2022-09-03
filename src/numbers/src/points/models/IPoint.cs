//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPoint<T>
        where T : unmanaged
    {
        T X {get;}

        T Y {get;}
    }

    public interface IPoint<F,T> : IPoint<T>, IEquatable<F>, IComparable<F>
        where T : unmanaged
        where F : IPoint<F,T>
    {

    }
}