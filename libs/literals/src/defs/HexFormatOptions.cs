//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexFormatSpecs;

    /// <summary>
    /// Defines a common set of hex formatting options
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct HexFormatOptions
    {
        [MethodImpl(Inline)]
        public static HexFormatOptions define(bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true,
            bool delimitsegs = true, char? segsep = null, bool delimitblocks = false, char? blocksep = null, char? valsep = null)
        {
            var dst = new HexFormatOptions();
            dst.ZeroPad = zpad;
            dst.CaseIndicator = CaseSpec(uppercase);
            dst.Specifier = specifier;
            dst.Uppercase = uppercase;
            dst.PreSpec = prespec;
            dst.DelimitSegs = delimitsegs;
            dst.SegDelimiter = segsep ?? DataDelimiter;
            dst.DelimitBlocks = delimitblocks;
            dst.BlockDelimiter = blocksep ?? Chars.Null;
            dst.BlockWidth = 0;
            dst.ValueDelimiter = valsep ?? DataDelimiter;
            return dst;
        }

        /// <summary>
        /// Indicates whether the numeric content should be left-padded with zeros
        /// </summary>
        public bool ZeroPad;

        /// <summary>
        /// Indicates whether a hex specifier, either prefixing or suffixing the numeric content, should be emitted
        /// </summary>
        public bool Specifier;

        /// <summary>
        /// Indicates whether the hex digits 'A',..,'F' should be upper-cased
        /// </summary>
        public bool Uppercase;

        /// <summary>
        /// Indicates whether the hex numeric specifier, if emitted, prefix the output
        /// </summary>
        public bool PreSpec;

        /// <summary>
        /// The case format character, either 'X' or 'x'
        /// </summary>
        public char CaseIndicator;

        /// <summary>
        /// Specifies whether segments should be delimited
        /// </summary>
        public bool DelimitSegs;

        /// <summary>
        /// Sepcifies the segment delimiter, if applicable
        /// </summary>
        public char SegDelimiter;

        /// <summary>
        /// Specifies blocks, comprised of segments, should be delimited
        /// </summary>
        public bool DelimitBlocks;

        /// <summary>
        /// The block delimiter, if applicable
        /// </summary>
        public char BlockDelimiter;

        /// <summary>
        /// The width of a block, if applicable
        /// </summary>
        public ushort BlockWidth;

        /// <summary>
        /// The value delimiter
        /// </summary>
        public char ValueDelimiter;
    }
}