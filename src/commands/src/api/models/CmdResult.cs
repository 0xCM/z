//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdResult
    {
        record struct EmptyCommand : IWfCmd<EmptyCommand>
        {

        }

        public ICmd Cmd {get;}

        public ExecToken Token {get;}

        public bool Succeeded {get;}

        public dynamic Payload {get;}

        [MethodImpl(Inline)]
        public CmdResult()
        {
            Cmd = new EmptyCommand();
            Token = ExecToken.Empty;
            Succeeded = false;
            Payload = null;
        }

        [MethodImpl(Inline)]
        public CmdResult(ICmd cmd, ExecToken token, bool success, dynamic? payload = null)
        {
            Cmd = cmd;
            Token = token;
            Succeeded = success;
            Payload = payload ?? new object();
        }

        public static CmdResult Empty
            => new ();
    }
}