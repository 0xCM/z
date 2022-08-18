//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INonZero<T>
        where T : unmanaged
    {
        T Value {get;}
    }

    [Free]
    public interface INonZero<F,T> : INonZero<T>, IEquatable<F>
        where F : unmanaged, INonZero<F,T>
        where T : unmanaged
    {

    }
}