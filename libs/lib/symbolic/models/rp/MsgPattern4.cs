//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsgPattern<A0,A1,A2,A3> : IMsgPattern<MsgPattern<A0,A1,A2,A3>,A0,A1,A2,A3>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public MsgPattern(string src)
            => PatternText = src;

        public string Format(in A0 a0, in A1 a1, in A2 a2, in A3 a3)
            => string.Format(PatternText, $"<{a0}>", $"<{a1}>", $"<{a2}>", $"<{a3}>");

        public MsgCapture Capture(in A0 a0, in A1 a1, in A2 a2, in A3 a3)
            => MsgOps.message(this, $"<{a0}>", $"<{a1}>", $"<{a2}>", $"<{a3}>");

        [MethodImpl(Inline)]
        public static implicit operator MsgPattern<A0,A1,A2,A3>(string src)
            => new MsgPattern<A0,A1,A2,A3>(src);
    }
}