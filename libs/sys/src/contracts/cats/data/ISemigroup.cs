//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISemigroup<T>
    {

    }

    [Free]
    public interface ISemigroup<F,T> : ISemigroup<T>
        where F : ISemigroup<F,T>, new()
    {

    }
}