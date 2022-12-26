//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StatusMsg<T> : IAppMsg
    {
        public const MsgLevel Level = MsgLevel.Status;

        public MsgId MsgId {get;}

        public MsgPayload<T> Payload {get;}

        [MethodImpl(Inline)]
        public StatusMsg(T data)
        {
            MsgId = (Level, Timestamp.now());
            Payload = data;
        }

        public MsgFlair Flair
            => MsgFlair.Status;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0} | {1}", MsgId, Payload);

        public override string ToString()
            => Format();

        LogLevel IAppMsg.Kind
            => (LogLevel)Level;

        FlairKind IAppMsg.Flair
             => (FlairKind)Flair;
    }
}