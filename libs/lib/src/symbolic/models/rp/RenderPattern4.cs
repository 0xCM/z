//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MsgOps;

    public readonly struct RenderPattern<A0,A1,A2,A3> : IFormatPattern<RenderPattern<A0,A1,A2,A3>,A0,A1,A2,A3>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public RenderPattern(string src)
            => PatternText = src;

        [MethodImpl(Inline)]
        public string Format(in A0 a0, in A1 a1, in A2 a2, in A3 a3)
            => string.Format(PatternText, a0, a1, a2, a3);

        [MethodImpl(Inline)]
        public RenderCapture Capture(in A0 a0, in A1 a1, in A2 a2, in A3 a3)
            => api.render(this, a0, a1, a2, a3);

        [MethodImpl(Inline)]
        public static implicit operator RenderPattern<A0,A1,A2,A3>(string src)
            => new RenderPattern<A0,A1,A2,A3>(src);
    }
}