//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FormatFunction : ITextFormatter
    {
        public Type SourceType {get;}

        readonly FormatterDelegate F;

        [MethodImpl(Inline),Op]
        public FormatFunction(Type target, FormatterDelegate f)
        {
            SourceType = target;
            F = f;
        }

        [MethodImpl(Inline),Op]
        public string Format(dynamic src)
            => F(src);
    }
}