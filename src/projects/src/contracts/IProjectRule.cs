//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectRule
    {
        
    }

    public interface IProjectRule<R> : IProjectRule
        where R : IProjectRule<R>, new()
    {

    }

}