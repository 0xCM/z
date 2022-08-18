//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderPattern<A0,A1> : IFormatPattern<RenderPattern<A0,A1>,A0,A1>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public RenderPattern(string src)
            => PatternText= src;

        [MethodImpl(Inline)]
        public string Format(in A0 s0, in A1 s1)
            => string.Format(PatternText, s0, s1);

        [MethodImpl(Inline)]
        public RenderCapture Capture(in A0 s0, in A1 s1)
            => MsgOps.render(this, s0, s1);

        [MethodImpl(Inline)]
        public static implicit operator RenderPattern<A0,A1>(string src)
            => new RenderPattern<A0,A1>(src);
    }
}