//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfCmd : ICmd
    {

    }

    public interface IWfCmd<C> : IWfCmd, ICmd<C>
        where C : ICmd<C>, new()
    {

    }
}