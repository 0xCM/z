//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static Scalars;
    using static Sized;

    using static HexFormatSpecs;
    using static HexOptionData;

    using SK = HexSpecKind;

    [ApiHost]
    public readonly struct HexFormatter
    {
        const NumericKind Closure = UnsignedInts;

        public static string spec(W8 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex8SpecUC : Hex8Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W8i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w8, pad, @case);

        public static string spec(W16 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex16SpecUC : Hex16Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W16i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w16, pad, @case);

        public static string spec(W32 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex32SpecUC : Hex32Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W32i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w32, pad, @case);

        public static string spec(W64 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex64SpecUC : Hex64Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W64i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w64, pad, @case);

        public static string spec(W8 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => Hex8Spec) : digits.Map(n => $"X{n}", () => Hex8SpecUC);

        public static string spec(W16 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => Hex16Spec) : digits.Map(n => $"X{n}", () => Hex16SpecUC);

        public static string spec(W32 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => Hex32Spec) : digits.Map(n => $"X{n}", () => Hex32SpecUC);

        public static string spec(W64 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => "x") : digits.Map(n => $"X{n}", () => "X");

        /// <summary>
        /// Returns the number of characters that precede a null-terminator, if any; otherwise returns the lenght of the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        static uint length(ReadOnlySpan<char> src)
        {
            var counter = 0u;
            var max = (uint)src.Length;

            if(max == 0)
                return 0;

            for(var i=0u; i<max; i++)
                if(sys.skip(src,i) == 0)
                    return i;
            return max;
        }

        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        static bool begins(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
            => length(src) != 0 && src.StartsWith(match);

        [MethodImpl(Inline)]
        static bool HasPrespec(ReadOnlySpan<char> src)
            => src.Length > 2 && begins(src,"0x");

        [MethodImpl(Inline)]
        public static bool HasPostspec(ReadOnlySpan<char> src)
            => src.Length > 0 && sys.skip(src, src.Length - 1) == 'h';

        [MethodImpl(Inline)]
        public static bool HasSpec(ReadOnlySpan<char> src)
            => HasPrespec(src) || HasPostspec(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<char> ClearPrespec(ReadOnlySpan<char> src)
            => HasPrespec(src) ? sys.slice(src,2) : src;

        [Op, Closures(Closure)]
        public static string format<T>(ReadOnlySpan<T> src, in HexFormatOptions config)
            where T : unmanaged
        {
            var result = new StringBuilder();
            var count = src.Length;
            for(var i = 0; i<count; i++)
            {
                var formatted = format(sys.skip(src,i), config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);
                result.Append(formatted);
                if(i != count - 1)
                    result.Append(config.ValueDelimiter);
            }

            return result.ToString();
        }

        [Op, Closures(Closure)]
        public static void quoted<T>(T src, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
                => quoted_u(src, null, 0, @case, dst);

        [MethodImpl(Inline)]
        static void quoted_u<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                dst.Append(RP.enquote(format8u(uint8(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ushort))
                dst.Append(RP.enquote(format16u(uint16(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(uint))
                dst.Append(RP.enquote(format32u(uint32(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ulong))
                dst.Append(RP.enquote(format64u(uint64(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else
                quoted_i(src,digits, spec, @case,dst);
        }

        [MethodImpl(Inline)]
        static void quoted_i<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                dst.Append(RP.enquote(format8i(int8(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ushort))
                dst.Append(RP.enquote(format16i(int16(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(uint))
                dst.Append(RP.enquote(format32i(int32(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ulong))
                dst.Append(RP.enquote(format64i(int64(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else
                quoted_x(src, digits, spec, @case, dst);
        }

        [MethodImpl(Inline)]
        static void quoted_x<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            if(size<T>() == 1)
                dst.Append(RP.enquote(format8u(bw8(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(size<T>() == 2)
                dst.Append(RP.enquote(format16u(bw16(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(size<T>() == 4)
                dst.Append(RP.enquote(format32u(bw32(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else
                dst.Append(RP.enquote(format64u(bw64(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
        }

        /// <summary>
        /// Formats a span pf presumed integral values as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to format the result as a vector</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="prespec">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static string format<T>(ReadOnlySpan<T> src, char sep = Chars.Space, bool prespec = false, bool uppercase = false)
            where T : unmanaged
        {
            var result = new StringBuilder();
            var count = src.Length;
            for(var i = 0; i<count; i++)
            {
                result.Append(format(sys.skip(src,i), true, prespec, uppercase:uppercase, prespec:true));
                if(i != count - 1)
                    result.Append(sep);
            }

            return result.ToString();
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ISystemFormatter<T> sysformatter<T>()
            where T : struct
                => system_u<T>();

        /// <summary>
        /// Formats a sequence of primal numeric calls as data-formatted hex
        /// </summary>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string array<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => formatter<T>().Format(src, HexArrayOptions);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HexFormatter<T> formatter<T>()
            where T : unmanaged
                => new HexFormatter<T>(sysformatter<T>());

        [Op]
        public static string format(ReadOnlySpan<byte> src, in HexFormatOptions config)
        {
            int? blockwidth = null;
            var dst = new StringBuilder();
            var count = src.Length;
            var pre = (config.Specifier && config.PreSpec) ? "0x" : EmptyString;
            var post = (config.Specifier && !config.PreSpec) ? "h" : EmptyString;
            var spec = CaseSpec(config.Uppercase).ToString();
            var width = config.BlockWidth == 0 ? ushort.MaxValue : config.BlockWidth;
            var counter = 0;

            for(var i=0; i<count; i++)
            {
                var value = sys.skip(src,i).ToString(spec);
                var padded = config.ZeroPad ? value.PadLeft(2, Chars.D0) : value;
                dst.Append(string.Concat(pre, padded, post));
                if(config.DelimitSegs && i != count - 1)
                    dst.Append(config.SegDelimiter);

                if(++counter >= width && config.DelimitBlocks)
                {
                    if(config.BlockDelimiter == Chars.NL || config.BlockDelimiter == Chars.CR)
                        dst.AppendLine();
                    else
                        dst.Append(config.BlockDelimiter);
                    counter = 0;
                }
            }

            return dst.ToString();
        }

        [Op]
        public static string format(W8 w, byte src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex8Spec) : src.ToString(Hex8SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W8i w, sbyte src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex8Spec) : src.ToString(Hex8SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16 w, ushort src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex16Spec) : src.ToString(Hex16SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16i w, short src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex16Spec) : src.ToString(Hex16SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32 w, uint src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex32Spec) : src.ToString(Hex32SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32i w, int src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex32Spec) : src.ToString(Hex32SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64 w, ulong src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex64Spec) : src.ToString(Hex64SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64i w, long src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex64Spec) : src.ToString(Hex64SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W8 w, byte src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W8i w, sbyte src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16 w, ushort src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16i w, short src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32 w, uint src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32i w, int src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w,pad,@case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64 w, ulong src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64i w, long src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(NativeSize size, ulong src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8, (byte)src, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16,(ushort)src, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32,(uint)src, prespec, postspec, @case),
                _ => format(w64,src, prespec, postspec, @case)
            };

        [Op]
        public static string format(NativeSize size, long src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8i, (sbyte)src, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16i,(short)src, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32i,(int)src, prespec, postspec, @case),
                _ => format(w64i,src, prespec, postspec, @case)
            };

        [Op]
        public static string format(NativeSize size, ulong src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8, (byte)src, pad, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16,(ushort)src, pad, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32,(uint)src, pad, prespec, postspec, @case),
                _ => format(w64,src, pad, prespec, postspec, @case)
            };

        [Op]
        public static string format(NativeSize size, long src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8i, (sbyte)src, pad, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16i,(short)src, pad, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32i,(int)src, pad, prespec, postspec, @case),
                _ => format(w64i, src, pad, prespec, postspec, @case)
            };

        [Op]
        public static string asmhex(sbyte src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex8Spec)) + PostSpec;

        [Op]
        public static string asmhex(byte src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex8Spec)) + PostSpec;

        [Op]
        public static string asmhex(short src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex16Spec)) + PostSpec;

        [Op]
        public static string asmhex(ushort src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex16Spec)) + PostSpec;

        [Op]
        public static string asmhex(int src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + PostSpec;

        [Op]
        public static string asmhex(uint src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x8")) + PostSpec;

        [Op]
        public static string asmhex(ulong src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + PostSpec;

        [Op]
        public static string asmhex(long src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + PostSpec;

        [Op]
        public static string format8u(byte src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w8, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format8i(sbyte src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w8, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format16i(short src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w16, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format16u(ushort src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w16, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format32i(int src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w32, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format32u(uint src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w32, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format64i(long src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w64, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format64u(ulong src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w64, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string bytes(ushort src)
            => format(sys.bytes(src), HexDataOptions);

        [Op]
        public static string bytes(short src)
            => format(sys.bytes(src), HexDataOptions);

        [Op]
        public static string bytes(int src)
            => format(sys.bytes(src), HexDataOptions);

        [Op]
        public static string bytes(uint src)
            => format(sys.bytes(src), HexDataOptions);

        [Op]
        public static string bytes(long src)
            => format(sys.bytes(src), HexDataOptions);

        [Op]
        public static string bytes(ulong src)
            => format(sys.bytes(src), HexDataOptions);

        public static string bytes<T>(T src)
            where T : unmanaged
                => format(sys.bytes(src), HexDataOptions);

        public interface ISystemFormatter<T>
            where T : struct
        {

        }

        public interface ISystemFormatter<F,T> : ISystemFormatter<T>
            where F : struct, ISystemFormatter<F,T>
            where T : struct
        {

        }

        [Op, Closures(AllNumeric)]
        public static string format<T>(T src, bool zpad, bool specifier, bool uppercase = false, bool prespec = true)
            where T : unmanaged
                => format_u(src, zpad, specifier, uppercase, prespec);

        [MethodImpl(Inline)]
        static string format_u<T>(T src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return uint8(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(ushort))
                return uint16(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(uint))
                return uint32(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(ulong))
                return uint64(src).FormatHex(zpad, specifier, uppercase, prespec);
            else
                return format_i(src,zpad,specifier,uppercase,prespec);
        }

        [MethodImpl(Inline)]
        static string format_i<T>(T src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return int8(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(short))
                return int16(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(int))
                return int32(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(long))
                return int64(src).FormatHex(zpad, specifier, uppercase, prespec);
            else
                return format_f(src,zpad,specifier,uppercase,prespec);
        }

        [MethodImpl(Inline)]
        static string format_f<T>(T src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return float32(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(double))
                return float64(src).FormatHex(zpad, specifier, uppercase, prespec);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op]
        public static string format<W,T>(T value, W w = default, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            where W : unmanaged, IDataWidth
            where T : unmanaged
        {
            if(typeof(W) == typeof(W8))
                return format(w8, bw8(value), postspec:postspec, @case:@case);
            else if(typeof(W) == typeof(W16))
                return format(w16, bw16(value), postspec:postspec, @case:@case);
            else if(typeof(W) == typeof(W32))
                return format(w32, bw32(value), postspec:postspec, @case:@case);
            else
                return format(w64, bw64(value), postspec:postspec, @case:@case);
        }

        [MethodImpl(Inline)]
        internal static ISystemFormatter<T> system_u<T>()
            where T : struct
        {
            if(typeof(T) == typeof(byte))
                return generalize<HexFormatter8u,ISystemFormatter<T>>(HexFormatter8u.Service);
            else if(typeof(T) == typeof(ushort))
                return generalize<HexFormatter16u,ISystemFormatter<T>>(HexFormatter16u.Service);
            else if(typeof(T) == typeof(uint))
                return generalize<HexFormatter32u,ISystemFormatter<T>>(HexFormatter32u.Service);
            else if(typeof(T) == typeof(ulong))
                return generalize<HexFormatter64u,ISystemFormatter<T>>(HexFormatter64u.Service);
            else
                return system_i<T>();
        }

        [MethodImpl(Inline)]
        static ISystemFormatter<T> system_i<T>()
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return generalize<HexFormatter8i,ISystemFormatter<T>>(HexFormatter8i.Service);
            else if(typeof(T) == typeof(short))
                return generalize<HexFormatter16i,ISystemFormatter<T>>(HexFormatter16i.Service);
            else if(typeof(T) == typeof(int))
                return generalize<HexFormatter32i,ISystemFormatter<T>>(HexFormatter32i.Service);
            else if(typeof(T) == typeof(long))
                return generalize<HexFormatter64i,ISystemFormatter<T>>(HexFormatter64i.Service);
            else
                return system_f<T>();
        }

        [MethodImpl(Inline)]
        static ISystemFormatter<T> system_f<T>()
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return generalize<HexFormatter32f,ISystemFormatter<T>>(HexFormatter32f.Service);
            else if(typeof(T) == typeof(double))
                return generalize<HexFormatter64f,ISystemFormatter<T>>(HexFormatter64f.Service);
            else
                throw no<T>();
        }

        readonly struct HexFormatter8i : ISystemFormatter<HexFormatter8i,sbyte>
        {
            public static HexFormatter8i Service => default;

            [MethodImpl(Inline)]
            public string Format(sbyte src, string format = null)
                => src.ToString(format ?? string.Empty);
        }

        readonly struct HexFormatter8u : ISystemFormatter<HexFormatter8u,byte>
        {
            public static HexFormatter8u Service => default;

            [MethodImpl(Inline)]
            public string Format(byte src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter16i : ISystemFormatter<HexFormatter16i,short>
        {
            public static HexFormatter16i Service => default;

            [MethodImpl(Inline)]
            public string Format(short src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter16u : ISystemFormatter<HexFormatter16u,ushort>
        {
            public static HexFormatter16u Service =>  default;

            [MethodImpl(Inline)]
            public string Format(ushort src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter32i : ISystemFormatter<HexFormatter32i,int>
        {
            public static HexFormatter32i Service => default;

            [MethodImpl(Inline)]
            public string Format(int src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter32u : ISystemFormatter<HexFormatter32u,uint>
        {
            public static HexFormatter32u Service =>  default;

            [MethodImpl(Inline)]
            public string Format(uint src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter64i : ISystemFormatter<HexFormatter64i,long>
        {
            public static HexFormatter64i Service =>  default;

            [MethodImpl(Inline)]
            public string Format(long src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter64u : ISystemFormatter<HexFormatter64u,ulong>
        {
            public static HexFormatter64u Service =>  default;

            [MethodImpl(Inline)]
            public string Format(ulong src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter32f : ISystemFormatter<HexFormatter32f,float>
        {
            public static HexFormatter32f Service =>  default;

            [MethodImpl(Inline)]
            public string Format(float src, string format = null)
                => BitConverter.SingleToInt32Bits(src).ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter64f : ISystemFormatter<HexFormatter64f,double>
        {
            public static HexFormatter64f Service =>  default;

            [MethodImpl(Inline)]
            public string Format(double src, string format = null)
                => BitConverter.DoubleToInt64Bits(src).ToString(format ?? EmptyString);
        }

        [MethodImpl(Inline)]
        static ref readonly F generalize<X,F>(in X src)
            where X : struct
                => ref sys.@as<X,F>(src);
    }
}