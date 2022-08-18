//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsgCapture : IMsgCapture
    {
        readonly IMsgPattern Pattern;

        readonly object[] Args;

        public string PatternText
            => Pattern.PatternText;

        public byte ArgCount
            => Pattern.ArgCount;

        public ReadOnlySpan<Type> ArgTypes
            => Pattern.ArgTypes;

        [MethodImpl(Inline)]
        internal MsgCapture(IMsgPattern pattern, object[] args)
        {
            Pattern = pattern;
            Args = args;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Pattern.PatternText, Args);

        public override string ToString()
            => Format();

        public static implicit operator string(MsgCapture src)
            => src.Format();
    }
}