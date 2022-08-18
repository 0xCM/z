//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static HexFormatSpecs;

    using X = HexDigitFacets;
    using D = HexDigitFacets;

    partial struct Hex
    {
        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(AsciCode c, out byte dst)
        {
            if(scalar(c))
            {
                dst = (byte)((byte)c - MinScalarCode);
                return true;
            }
            else if(upper(c))
            {
                dst = (byte)((byte)c - MinCharCodeU + 0xA);
                return true;
            }
            else if(lower(c))
            {
                dst = (byte)((byte)c - MinCharCodeL + 0xa);
                return true;
            }
            dst = byte.MaxValue;
            return false;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, AsciCode c, out byte dst)
        {
            var result = false;
            if(scalar(c))
            {
                dst = (byte)((byte)c - MinScalarCode);
                result = true;
            }
            else if(upper(c))
            {
                dst = (byte)((byte)c - MinCharCodeU + 0xA);
                result = true;
            }
            else
                dst = byte.MaxValue;

            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, AsciCode c, out byte dst)
        {
            var result = false;
            if(scalar(c))
            {
                dst = (byte)((byte)c - MinScalarCode);
                result = true;
            }
            else if(lower(c))
            {
                dst = (byte)((byte)c - MinCharCodeL + 0xa);
                result = true;
            }
            else
                dst = byte.MaxValue;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, AsciCode c, out HexDigitValue dst)
        {
            var result = false;

            if(scalar(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinScalarCode);
                result = true;
            }
            else if(upper(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinLetterCodeU + 0xA);
                result = true;
            }
            else
                dst = (HexDigitValue)byte.MaxValue;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, AsciCode c, out HexDigitValue dst)
        {
            var result = false;
            if(scalar(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinScalarCode);
                result = true;
            }
            else if(lower(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinLetterCodeL + 0xa);
                result = true;
            }
            else
                dst = (HexDigitValue)byte.MaxValue;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(AsciCode c, out HexDigitValue dst)
        {
            if(scalar(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - X.MinScalarCode);
                return true;
            }
            else if(upper(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - X.MinLetterCodeU + 0xA);
                return true;
            }
            else if(lower(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - X.MinLetterCodeL + 0xa);
                return true;
            }
            dst = (HexDigitValue)byte.MaxValue;
            return false;
        }

        [Op]
        public static bool parse(AsciCharSym src, out HexDigitValue dst)
            => parse((AsciCode)src, out dst);

        [Op]
        public static Outcome<uint> parse(ReadOnlySpan<AsciCode> src, ref uint offset, Span<byte> dst)
        {
            var i0 = offset;
            var counter = 0u;
            var count = src.Length;
            ref var target = ref first(dst);
            var hi = byte.MaxValue;
            var lo = byte.MaxValue;
            for(var j=0; j<count; j++, offset++)
            {
                ref readonly var c = ref skip(src,j);
                if(SQ.whitespace(c) || Hex.specifier(c))
                    continue;

                if(Hex.parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        lo = (byte)d;
                        seek(target, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                        lo = byte.MaxValue;
                    }
                }
                else
                    return false;
            }
            return (true, counter);
        }

        [Op]
        public static bool parse(ReadOnlySpan<AsciCode> src, out ulong dst)
        {
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            return ulong.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out dst);
        }

        [Op]
        public static bool parse(ReadOnlySpan<AsciCode> src, out Hex16 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = ushort.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        [Op]
        public static bool parse(ReadOnlySpan<AsciCode> src, out Hex32 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = uint.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        [Op]
        public static bool parse(ReadOnlySpan<AsciCode> src, out Hex64 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = ulong.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        public static bool parse(ReadOnlySpan<AsciCode> src, out MemoryAddress dst)
        {
            var result = parse(clear(src), out Hex64 x64);
            if(result)
            {
                dst = x64;
                return true;
            }
            else
            {
                dst = MemoryAddress.Zero;
                return false;
            }
        }

        [MethodImpl(Inline)]
        static bool whitespace(AsciCode src)
            => SQ.contains(AsciCodes.whitespace(), src);
    }
}