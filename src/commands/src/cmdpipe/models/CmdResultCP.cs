//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdResult<C,P> : ICmdResult<C,P>
        where C : ICmd, new()
        where P : INullity, new()
    {
        public C Spec {get;}

        public ExecToken Token {get;}

        public bool Succeeded {get;}

        public P Payload {get;}

        [MethodImpl(Inline)]
        public CmdResult()
        {
            Spec = new();
            Token = ExecToken.Empty;
            Succeeded = false;
            Payload = new();
        }

        [MethodImpl(Inline)]
        public CmdResult(C cmd, ExecToken token, bool success, P payload)
        {
            Spec = cmd;
            Token = token;
            Succeeded = success;
            Payload = payload ?? new P();
        }

        public static CmdResult<C,P> Empty
            => new();

        public static implicit operator CmdResult(CmdResult<C,P> src)
            => new CmdResult(src.Spec, src.Token, src.Succeeded, src.Payload);
    }
}