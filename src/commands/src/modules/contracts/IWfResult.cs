//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfResult
    {
        CmdUri TaskName {get;}

        ExecToken Token {get;}
    }

    public interface IWfResult<R> : IWfResult
        where R : new()
    {

    }
}