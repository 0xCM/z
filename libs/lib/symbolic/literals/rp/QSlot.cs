//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        public const string Quote = "\"";

        public const string QuotedSlot = Quote + "{0}" + Quote;

        public const string QuotedSlot1 = Quote + "{1}" + Quote;

        public const string QuotedSlot2 = Quote + "{2}" + Quote;

        public const string QuotedSlot3 = Quote + "{3}" + Quote;

        /// <summary>
        /// Defines the literal '"{1}"'
        /// </summary>
        public const string QSlot1 = OpenQSlot + D1 + CloseQSlot;

        /// <summary>
        /// Defines the literal '"{2}"'
        /// </summary>
        public const string QSlot2 = OpenQSlot + D2 + CloseQSlot;

        /// <summary>
        /// Defines the literal '"{3}"'
        /// </summary>
        public const string QSlot3 = OpenQSlot + D3 + CloseQSlot;

        /// <summary>
        /// Defines the literal '"{4}"'
        /// </summary>
        public const string QSlot4 = OpenQSlot + D4 + CloseQSlot;

        /// <summary>
        /// Defines the literal '"{'
        /// </summary>
        [RenderLiteral("\"{")]
        public const string OpenQSlot = DQuote + OpenSlot;

        /// <summary>
        /// Defines the literal '"}'
        /// </summary>
        [RenderLiteral("\"}")]
        public const string CloseQSlot = RBrace + DQuote;

        /// <summary>
        /// Defines the literal '"{0}"'
        /// </summary>
        [RenderLiteral("\"{\"}")]
        public const string QSlot0 = OpenQSlot + D0 + CloseQSlot;
    }
}