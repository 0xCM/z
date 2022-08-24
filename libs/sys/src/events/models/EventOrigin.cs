//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EventOrigin : IExpr
    {
        public readonly @string OriginName;

        public readonly CallingMember Caller;

        [MethodImpl(Inline)]
        public EventOrigin(string name, in CallingMember caller)
        {
            OriginName = name;
            Caller = caller;
        }

        public EventOrigin(string caller, string file, uint line)
        {
            Caller = new (caller,file,(int)line);
            OriginName = caller;
        }

        public bool IsEmpty
            => OriginName.IsEmpty;

        public string Format()
            => MsgOps.piped(OriginName, Caller);

        public override string ToString()
            => Format();

        public static EventOrigin Empty => new EventOrigin(EmptyString, CallingMember.Empty);
    }
}