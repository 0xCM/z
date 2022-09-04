//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IUrl
    {

    }
    
    public interface IUrl<I> : IUrl
        where I : IUri
    {


    }

    public abstract record class Url<U,I>
        where U : Url<U,I>, new()
        where I : IUri
    {


    }
}