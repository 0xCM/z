//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IIndicator
    {
        bit Enabled {get;}

        dynamic Value {get;}
    }

    [Free]
    public interface IIndicator<T> : IIndicator
        where T : unmanaged
    {
        new T Value {get;}

        dynamic IIndicator.Value
            => Value;
    }

    [Free]
    public interface IIndicator<F,T> : IIndicator<T>, IComparable<F>, IEquatable<F>
        where T : unmanaged
        where F : unmanaged, IIndicator<F,T>
    {

    }
}