//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdPipe<C,S0,P0,S1,P1>
        where S0 : IApiCmd, new()
        where S1 : IApiCmd, new()
        where P0 : INullity, new()
        where P1 : INullity, new()
    {
        ICmdExecutor<S1,P1> Next(CmdResult<S0,P0> src);
    }
}