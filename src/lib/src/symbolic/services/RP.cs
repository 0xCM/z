//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct RpOps
    {
        const NumericKind Closure = UnsignedInts;


        /// <summary>
        /// The end-of-line escape sequence
        /// </summary>
        public const string Eol = Chars.Eol;

        public const char PropertySep = Chars.Colon;

        public const sbyte PropertyPad = -16;

        /// <summary>
        /// Defines the literal '{0} -> {1}'
        /// </summary>
        [RenderPattern(2, "{0} -> {1}")]
        public const string ArrowAxB = "{0} -> {1}";
    }
}