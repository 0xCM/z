//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderPattern<T> : IFormatPattern<RenderPattern<T>,T>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public RenderPattern(string src)
            => PatternText = src;

        [MethodImpl(Inline)]
        public string Format(in T src)
            => string.Format(PatternText, src);

        [MethodImpl(Inline)]
        public RenderCapture Capture(in T src)
            => MsgOps.render(this, src);

        [MethodImpl(Inline)]
        public static implicit operator RenderPattern<T>(string src)
            => new RenderPattern<T>(src);
    }
}