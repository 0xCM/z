//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        [RenderLiteral(Dash1, 1)]
        public const string Dash1 = "-";

        [RenderLiteral(Dash2, 2)]
        public const string Dash2 = Dash1 + Dash1;

        [RenderLiteral(Dash3, 3)]
        public const string Dash3 = Dash2 + Dash1;

        /// <summary>
        /// Defines a literal consisting of 4 '-' characters
        /// </summary>
        [RenderLiteral(Dash4, 4)]
        public const string Dash4 = Dash3 + Dash1;

        /// <summary>
        /// Defines a literal consisting of 5 '-' characters
        /// </summary>
        [RenderLiteral(Dash5, 5)]
        public const string Dash5 = Dash4 + Dash1;

        /// <summary>
        /// Defines a literal consisting of 40 '-' characters
        /// </summary>
        [RenderLiteral(Dash40, 40)]
        public const string Dash40 = "----------------------------------------";

        /// <summary>
        /// Defines the default extension for structured data
        /// </summary>
        [RenderLiteral(Dash80, 80)]
        public const string Dash80 = Dash40 + Dash40;

        /// <summary>
        /// Delimiter between total/segment widths of a segmented type
        /// </summary>
        [RenderLiteral(SegSep)]
        public const string SegSep = "x";

        /// <summary>
        /// Pluralizes something
        /// </summary>
        [RenderLiteral(Plural,1)]
        public const string Plural = "s";

        /// <summary>
        /// Suffix used to pluralize a possessive
        /// </summary>
        [RenderLiteral(PluralPosses)]
        public const string PluralPosses = "'s";

        /// <summary>
        /// Defines the default field delimiter
        /// </summary>
        [RenderLiteral(FieldSep, 3)]
        public const string FieldSep = " | ";

        /// <summary>
        /// Defines the literal '.'
        /// </summary>
        [RenderLiteral(Dot, 1)]
        public const string Dot = ".";

        /// <summary>
        /// Defines the default extension delimiter
        /// </summary>
        [RenderLiteral(ExtSep)]
        public const string ExtSep = Dot;

        /// <summary>
        /// Defines the default extension for structured data
        /// </summary>
        [RenderLiteral(DataExt)]
        public const string DataExt = "csv";
    }
}