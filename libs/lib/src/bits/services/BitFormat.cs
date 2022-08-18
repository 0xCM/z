//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Controls formatting when bitstring content is rendered as text
    /// </summary>
    [ApiHost]
    public struct BitFormat
    {
        [MethodImpl(Inline), Op, Closures(NumericKind.UnsignedInts)]
        public static BitFormatter<T> formatter<T>(BitFormat config)
            where T : unmanaged
                => new BitFormatter<T>(config);

        [MethodImpl(Inline), Op]
        public static BitFormat configure(bool tlz)
            => define(tlz:tlz, specifier:false, blockWidth:null, blocksep:null, rowWidth:null, maxbits:null,zpad:null);

        [MethodImpl(Inline), Op]
        public static BitFormat configure()
            => define(tlz:false, specifier:false, blockWidth:null, blocksep:null, rowWidth:null, maxbits:null,zpad:null);

        [MethodImpl(Inline), Op]
        public static BitFormat limited(uint maxbits, int? zpad = null)
            => define(tlz:true, maxbits: maxbits, zpad:zpad);

        [MethodImpl(Inline), Op]
        public static BitFormat limited(uint maxbits, int zpad, bool specifier = false)
            => define(tlz:true, maxbits: maxbits, zpad:zpad, specifier:specifier);

        [MethodImpl(Inline), Op]
        public static BitFormat blocked(int width, char? sep = null, uint? maxbits = null, bool specifier = false)
            => define(tlz:false, blockWidth: width, blocksep: sep, maxbits:maxbits, specifier: specifier);

        [MethodImpl(Inline), Op]
        public static BitFormat define(bool tlz, bool specifier = false, int? blockWidth = null, char? blocksep = null, int? rowWidth = null, uint? maxbits = null, int? zpad = null)
            => new BitFormat(tlz, specifier, blockWidth, blocksep, rowWidth, maxbits, zpad);

        [MethodImpl(Inline), Op]
        public static BitFormat bitrows(int blockWidth, int rowWidth, char? blockSep = null)
            => define(tlz:false, blockWidth: blockWidth, rowWidth:rowWidth, blocksep: blockSep);

        /// <summary>
        /// Indicates whether leading zeros should be trimmed
        /// </summary>
        public bool TrimLeadingZeros;

        /// <summary>
        /// Indicates whether the '0b' prefix should be emitted
        /// </summary>
        public bool SpecifierPrefix;

        /// <summary>
        /// The maximum number of bits to be extracted/formatted from the source
        /// </summary>
        public uint MaxBitCount;

        /// <summary>
        /// Optional contiguous digit sequence width; if unspecified the bitstring will be formatted without blocks
        /// </summary>
        public int BlockWidth;

        /// <summary>
        /// The character with which to intersperse blocks; if unspecified, a space will be used
        /// </summary>
        public char BlockSep;

        /// <summary>
        /// The optional row width, applicable when formatting rectangular regions of bits
        /// </summary>
        public int RowWidth;

        /// <summary>
        /// The number of leading zeroes to pad
        /// </summary>
        public int ZPad;

        [MethodImpl(Inline)]
        public BitFormat(bool tlz = false, bool specifier = false, int? blockWidth = null, char? blocksep = null, int? rowWidth = null, uint? maxbits = null, int? zpad = null)
        {
            TrimLeadingZeros = tlz;
            SpecifierPrefix = specifier;
            BlockWidth = blockWidth ?? 0;
            BlockSep = blocksep ?? Chars.Space;
            RowWidth = rowWidth ?? 0;
            MaxBitCount = maxbits ?? uint.MaxValue;
            ZPad = zpad ?? 0;
        }

        [MethodImpl(Inline)]
        public BitFormat WithBlockWidth(uint width)
        {
            BlockWidth = (int)width;
            return this;
        }

        [MethodImpl(Inline)]
        public BitFormat WithRowWidth(uint width)
        {
            RowWidth = (int)width;
            return this;
        }

        [MethodImpl(Inline)]
        public BitFormat WithMaxBits(uint width)
        {
            MaxBitCount = width;
            return this;
        }

        [MethodImpl(Inline)]
        public BitFormat WithBlockSep(char sep)
        {
            BlockSep = sep;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator BitFormat(int width)
            => blocked(width, null, null,false);

        public static BitFormat Default
            => BitFormat.configure(false);
    }
}