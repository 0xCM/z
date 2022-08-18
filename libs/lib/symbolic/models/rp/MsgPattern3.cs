//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsgPattern<A0,A1,A2> : IMsgPattern<MsgPattern<A0,A1,A2>,A0,A1,A2>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public MsgPattern(string src)
            => PatternText = src;

        public string Format(in A0 a0, in A1 a1, in A2 a2)
            => string.Format(PatternText, $"<{a0}>", $"<{a1}>", $"<{a2}>");

        public MsgCapture Capture(in A0 a0, in A1 a1, in A2 a2)
            => MsgOps.message(this, $"<{a0}>", $"<{a1}>", $"<{a2}>");

        [MethodImpl(Inline)]
        public static implicit operator MsgPattern<A0,A1,A2>(string src)
            => new MsgPattern<A0,A1,A2>(src);
    }
}