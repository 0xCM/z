//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct CmdResult<C> : ICmdResult<C>
        where C : ICmd, new()
    {
        public C Cmd {get;}

        public ExecToken Token {get;}

        public bool Succeeded {get;}

        public TextBlock Message {get;}

        [MethodImpl(Inline)]
        public CmdResult()
        {
            Cmd = new();
            Token = ExecToken.Empty;
            Succeeded = false;
            Message = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdResult(C cmd, ExecToken token, bool success, string msg = EmptyString)
        {
            Cmd = cmd;
            Token = token;
            Succeeded = success;
            Message = msg ?? EmptyString;
        }

        public CmdId CmdId  => Cmd.CmdId;

        [MethodImpl(Inline)]
        public string Format()
            => Message;

        public override string ToString()
            => Format();

        public static CmdResult<C> Empty
            => new();
    }
}