//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Capures a command along with the outcome and payload
    /// </summary>
    public record CmdResult<C,P> : ICmdResult<C,P>
        where C : struct, ICmd
    {
        public C Cmd {get; set;}

        public bool Succeeded {get; set;}

        public P Payload {get; set;}

        public TextBlock Message {get; set;}

        public CmdId Id => Cmd.CmdId;

        public CmdResult()
        {
            Message = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdResult(in C cmd, bool success, P payload, string msg = EmptyString)
        {
            Cmd = cmd;
            Payload = payload;
            Succeeded = success;
            Message = ifempty(msg, CmdResult.DefaultMsg(cmd.CmdId, success));
        }

        [MethodImpl(Inline)]
        public CmdResult(in C cmd, Exception e)
        {
            Cmd = cmd;
            Payload = default;
            Succeeded = false;
            Message = e.ToString();
        }

        [MethodImpl(Inline)]
        public string Format()
            => Message;


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdResult(CmdResult<C,P> src)
            => new CmdResult(src.Id, src.Succeeded, src.Message);

        [MethodImpl(Inline)]
        public static implicit operator CmdResult<C>(CmdResult<C,P> src)
            => new CmdResult<C>(src.Cmd, src.Succeeded, src.Message);

        [MethodImpl(Inline)]
        public static implicit operator CmdResult<C,P>(CmdResult<C> src)
            => new CmdResult<C,P>(src.Cmd, src.Succeeded, default(P), src.Message);

        public static CmdResult<C,P> Empty
            => default;
    }
}