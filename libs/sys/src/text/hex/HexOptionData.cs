//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexFormatSpecs;

    public class HexOptionData
    {
        /// <summary>
        /// Specifies the default configuration for hex data emission
        /// </summary>
        public static HexFormatOptions HexDataOptions
        {
            [MethodImpl(Inline)]
            get => HexFormatOptions.define(true, false, false, false, true, DataDelimiter);
        }

        /// <summary>
        /// The default configuration for array initialization content
        /// </summary>
        public static HexFormatOptions HexArrayOptions
        {
            [MethodImpl(Inline)]
             get => HexFormatOptions.define(zpad:true, specifier:true, uppercase:false, prespec:true, delimitsegs:true, segsep:ListDelimiter, valsep: ListDelimiter);
        }

        public static HexFormatOptions CompactHexOptions
        {
            [MethodImpl(Inline)]
            get => HexFormatOptions.define(zpad:true, specifier:false, uppercase:true, prespec:false, delimitsegs:false, delimitblocks:false);
        }

        /// <summary>
        /// Defines the asci character codes for uppercase hex digits 1,2, ..., 9, A, ..., F
        /// </summary>
        public static ReadOnlySpan<byte> UpperHexDigits
            => new byte[]{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70};

        /// <summary>
        /// Defines the asci character codes for uppercase hex digits 1,2, ..., 9, a, ..., f
        /// </summary>
        public static ReadOnlySpan<byte> LowerHexDigits
            => new byte[]{48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102};
    }
}