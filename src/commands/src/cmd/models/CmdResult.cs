//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdResult : ITextual
    {
        public CmdId CmdId {get;}

        public bool Succeeded {get;}

        public dynamic Payload {get;}

        public string Message {get;}

        [MethodImpl(Inline)]
        public CmdResult(CmdId id, bool success)
        {
            CmdId = id;
            Succeeded = success;
            Message = DefaultMsg(id, success);
            Payload = Succeeded;
        }

        [MethodImpl(Inline)]
        public CmdResult(CmdId id, bool success, dynamic payload)
        {
            CmdId = id;
            Succeeded = success;
            Message = DefaultMsg(id, success);
            Payload = payload;
        }

        [MethodImpl(Inline)]
        public CmdResult(CmdId id, bool success, string message)
        {
            CmdId = id;
            Succeeded = success;
            Message = core.ifempty(message, DefaultMsg(id,success));
            Payload = Succeeded;
        }

        [MethodImpl(Inline)]
        public CmdResult(CmdId id, Exception e)
        {
            CmdId = id;
            Succeeded = false;
            Message = e.ToString();
            Payload = Succeeded;
        }

        [MethodImpl(Inline)]
        public static CmdResult FromOutcome<T>(CmdId id, Outcome<T> result)
            => new CmdResult(id, result.Ok, result.Message);

        public static string DefaultMsg(CmdId id, bool success)
            => string.Format("{0} execution {1}", id, success ? "succeeded" : "failed");

        [MethodImpl(Inline)]
        public string Format()
            => Message;

        public override string ToString()
            => Format();

        public static CmdResult Empty
            => default;
    }
}