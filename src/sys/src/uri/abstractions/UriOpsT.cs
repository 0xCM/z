//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class UriOps<T,U>
        where T : UriOps<T,U>, new()
        where U : IUri, new()
    {

    }
}