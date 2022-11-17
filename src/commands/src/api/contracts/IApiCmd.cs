//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiCmd : ICmd
    {

    }

    public interface IApiCmd<C> : IApiCmd, ICmd<C>
        where C : ICmd<C>, new()
    {

    }
}