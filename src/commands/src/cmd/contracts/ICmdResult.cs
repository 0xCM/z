//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdResult : ITextual
    {
        ICmd Cmd {get;}

        ExecToken Token {get;}

        bool Succeeded {get;}

        TextBlock Message {get;}

        CmdId CmdId 
            => Cmd.CmdId;
        string ITextual.Format()
            => Message;
    }

    [Free]
    public interface ICmdResult<C> : ICmdResult
        where C : ICmd, new()
    {
        new C Cmd {get;}
        ICmd ICmdResult.Cmd
            => Cmd;
    }

    [Free]
    public interface ICmdResult<C,P> : ICmdResult<C>
        where C : ICmd, new()
    {

    }
}