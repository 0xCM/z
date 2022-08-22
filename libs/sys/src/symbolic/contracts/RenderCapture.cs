//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderCapture : IExpr
    {
        readonly IFormatPattern Pattern;

        readonly object[] Args;

        [MethodImpl(Inline)]
        public RenderCapture(IFormatPattern pattern, object[] args)
        {
            Pattern = pattern;
            Args = args;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern != null;
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