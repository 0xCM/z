//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    [Free]
    public interface IToolFlow<T,A,B> : IFlow<A,B>
        where T : ITool, new()
    {
        T Tool {get;}
    }
}