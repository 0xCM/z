//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsgPattern<A0,A1> : IMsgPattern<MsgPattern<A0,A1>,A0,A1>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public MsgPattern(string src)
            => PatternText= src;

        public string Format(in A0 a0, in A1 a1)
            => string.Format(PatternText, $"<{a0}>", $"<{a1}>");

        public MsgCapture Capture(in A0 a0, in A1 a1)
            => MsgOps.message(this, $"<{a0}>", $"<{a1}>");

        [MethodImpl(Inline)]
        public static implicit operator MsgPattern<A0,A1>(string src)
            => new MsgPattern<A0,A1>(src);
    }
}