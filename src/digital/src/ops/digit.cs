//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexConst;

    using NBK = NumericBaseKind;

    using BSF = BinarySymFacet;
    using BDF = BinaryDigitFacets;
    using BDC = BinaryDigitCode;
    using BDS = BinaryDigitSym;
    using BDV = BinaryDigitValue;

    using ODF = OctalDigitFacets;
    using ODC = OctalDigitCode;
    using ODS = OctalDigitSym;
    using ODV = OctalDigitValue;

    using DDF = DecimalDigitFacets;
    using DSF = DecimalSymFacet;
    using DDS = DecimalDigitSym;
    using DDV = DecimalDigitValue;
    using DDC = DecimalDigitCode;

    using HDV = HexDigitValue;
    using HLS = HexLowerSym;
    using HUS = HexUpperSym;
    using XF = HexSymFacet;
    using XDF = HexDigitFacets;

    partial struct Digital
    {       
        /// <summary>
        /// Converts a character in the inclusive range [0,9] to the corresponding number in the same range
        /// </summary>
        /// <param name="c">The digit character</param>
        [MethodImpl(Inline), Op]
        public static ulong digit(char c)
            => (ulong)c - (ulong)'0';

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 7] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static ulong digit(ulong src, byte index)
            => 0xF & (src >> index*4);

        [MethodImpl(Inline), Op]
        public static BDV digit(BDS s)
            => (BDV)((BSF)s - BSF.First);

        [MethodImpl(Inline), Op]
        public static DDV digit(DDS s)
            => (DDV)((DSF)s - DSF.First);

        [MethodImpl(Inline), Op]
        public static BDV digit(Base2 @base, char c)
            => (BDV)((BSF)c - BSF.First);

        [MethodImpl(Inline), Op]
        public static bool digit(Base2 @base, char c, out BDV dst)
        {
            if(test(@base, c))
            {
                dst = (BDV)((BDC)c - BDF.MinCode);
                return true;
            }
            else
            {
                dst = (BDV)0xFF;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static ODV digit(ODS s)
            => (ODV)(s - ODS.o0);

        [MethodImpl(Inline), Op]
        public static ODV digit(Base8 @base, char c)
            => (ODV)((ODS)c - ODS.o0);

        [MethodImpl(Inline), Op]
        public static bool digit(Base8 @base, char c,  out ODV dst)
        {
            if(test(@base, c))
            {
                dst = (ODV)((ODC)c - ODF.MinCode);
                return true;
            }
            else
            {
                dst = (ODV)0xFF;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static bool digit(Base10 @base, char c, out DDV dst)
        {
            if(test(@base, c))
            {
                dst = (DDV)((DDC)c - DDF.MinCode);
                return true;
            }
            else
            {
                dst = (DDV)0xFF;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, char c)
            => (DDV)((DSF)c - DSF.First);

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 1] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, ushort src, byte index)
            => (DDV)(F & (src >> index*4));

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 3] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, uint src, byte index)
            => (DDV)(F & (src >> index*4));

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 7] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, ulong src, byte index)
            => (DDV)(F & (src >> index*4));

        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, char src)
        {
            if(number(src))
                return (HDV)((XF)src - XF.NumberOffset);
            else
            {
                if(hexupper(src))
                    return (HDV)((XF)src - XF.LetterOffsetUp);
                else
                    return (HDV)((XF)src - XF.LetterOffsetLo);
            }
        }

        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, AsciCode src)
        {
            if(number(src))
                return (HDV)((XF)src - XF.NumberOffset);
            else
            {
                if(hexupper(src))
                    return (HDV)((XF)src - XF.LetterOffsetUp);
                else
                    return (HDV)((XF)src - XF.LetterOffsetLo);
            }
        }

        /// <summary>
        /// Determines whether a character is one of [0..9]
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexscalar(char c)
            => (XF)c >= XF.FirstNumber && (XF)c <= XF.LastNumber;

        /// <summary>
        /// Determines whether a character is one of [0..9]
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexscalar(AsciCode c)
            => (XF)c >= XF.FirstNumber && (XF)c <= XF.LastNumber;

        /// <summary>
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexupper(char c)
            => (XF)c >= XF.FirstLetterUp && (XF)c <= XF.LastLetterUp;

        /// <summary>
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexupper(AsciCode c)
            => (XF)c >= XF.FirstLetterUp && (XF)c <= XF.LastLetterUp;

        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexlower(char c)
            => (XF)c >= XF.FirstLetterLo && (XF)c <= XF.LastLetterUp;

        [MethodImpl(Inline), Op]
        public static bool digit(Base16 @base, char c, out HDV dst)
            => Hex.parse(c, out dst);

        [Op]
        public static bool digit(NBK @base, char c, out byte dst)
        {
            dst = byte.MaxValue;
            switch(@base)
            {
                case NBK.Base2:
                if(digit(@base2, c, out var d2))
                {
                    dst = (byte)d2;
                    return true;
                }
                break;
                case NBK.Base8:
                if(digit(@base8, c, out var d8))
                {
                    dst = (byte)d8;
                    return true;
                }
                break;
                case NBK.Base10:
                if(digit(@base10, c, out var d10))
                {
                    dst = (byte)d10;
                    return true;
                }
                break;
                case NBK.Base16:
                if(digit(@base16, c, out var d16))
                {
                    dst = (byte)d16;
                    return true;
                }
                break;
            }
            return false;
        }

        /// <summary>
        /// Computes the numeric value in in the range [0,..,a,..,f] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, LowerCased @case, char src)
            => Hex.digit(@case, src);

        /// <summary>
        /// Computes the numeric value in in the range [0,..A,..,F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, UpperCased @case, char src)
            => Hex.digit(@case, src);

        /// <summary>
        /// Computes the numeric value in in the range [0,..,a,..,f] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(HLS src)
            => Hex.digit(src);

        /// <summary>
        /// Computes the numeric value in in the range [0,..A,..,F] identified by an uppercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(HUS src)
            => Hex.digit(src);

        [MethodImpl(Inline), Op]
        public static BinaryDigit digit(Base2 @base, bit src)
            => src;
    }
}