//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderCapture : ITextual
    {
        readonly IFormatPattern Pattern;

        readonly object[] Args;

        [MethodImpl(Inline)]
        internal RenderCapture(IFormatPattern pattern, object[] args)
        {
            Pattern = pattern;
            Args = args;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Pattern.PatternText, Args);

        public override string ToString()
            => Format();

        public static implicit operator string(RenderCapture src)
            => src.Format();
    }
}