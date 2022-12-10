//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly record struct CmdResult : ICmdResult
    {
        record struct EmptyCommand : IApiCmd<EmptyCommand>
        {

        }
        public ICmd Cmd {get;}

        public ExecToken Token {get;}

        public bool Succeeded {get;}

        public TextBlock Message {get;}

        [MethodImpl(Inline)]
        public CmdResult()
        {
            Cmd = new EmptyCommand();
            Token = ExecToken.Empty;
            Succeeded = false;
            Message = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdResult(ICmd cmd, ExecToken token, bool success, string message = EmptyString)
        {
            Cmd = cmd;
            Token = token;
            Succeeded = success;
            Message = message ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Message;

        public override string ToString()
            => Format();

        public static CmdResult Empty
            => new ();

        public CmdId CmdId 
            => Cmd.CmdId;
    }
}