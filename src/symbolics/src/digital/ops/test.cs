//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using B = BinaryDigitFacets;
    using O = OctalDigitFacets;
    using D = DecimalDigitFacets;
    using C = AsciCode;

    using static sys;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    partial struct Digital
    {
        /// <summary>
        /// Determines whether a code represents a binary digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, C src)
            => src == C.d0 || src == C.d1;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='OctalDigitCode'/> or <see cref='OctalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, char c)
            => (BinaryDigitCode)c >= B.MinCode && (BinaryDigitCode)c <= B.MaxCode;

        /// <summary>
        /// Determines whether a byte can be interpreted as a <see cref='OctalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, byte c)
            => (BinaryDigitValue)c >= B.MinDigit && (BinaryDigitValue)c <= B.MaxDigit;

       /// <summary>
        /// Determines whether an asci span segment defines a sequence of binary digits
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The sequence length</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, ReadOnlySpan<C> src, uint offset, uint count)
        {
            for(var i=offset; i<count+offset; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!test(@base, c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether a character span segment defines a sequence of binary digits
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The sequence length</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, ReadOnlySpan<char> src, uint offset, uint count)
        {
            for(var i=offset; i<count+offset; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!test(@base, c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='OctalDigitCode'/> or <see cref='OctalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base8 @base, char c)
            => (OctalDigitCode)c >= O.MinCode && (OctalDigitCode)c <= O.MaxCode;

        /// <summary>
        /// Determines whether a byte can be interpreted as a <see cref='OctalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base8 @base, byte c)
            => (OctalDigitValue)c >= O.MinDigit && (OctalDigitValue)c <= O.MaxDigit;

        /// <summary>
        /// Determines whether a code represents an octal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base8 @base, C src)
            => contains(C.d0, C.d7, src);        


        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='DecimalDigitCode'/> or <see cref='DecimalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base10 @base, char c)
            => (DecimalDigitCode)c >= D.MinCode && (DecimalDigitCode)c <= D.MaxCode;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='DecimalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base10 @base, byte c)
            => (DecimalDigitValue)c >= D.MinDigit && (DecimalDigitValue)c <= D.MaxDigit;

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base10 @base, C src)
            => contains(C.d0, C.d9, src);

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base10 @base, AsciCharSym src)
            => contains(C.d0, C.d9, (C)src);

        /// <summary>
        /// Returns the index of the first <see cref='Base10'/> digit found in the source
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static int digitIndex(Base10 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(test(base10, skip(src, i)))
                    return i;
            return NotFound;
        }

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base16 @base, char c)
            => scalar(@base, c) || upper(@base, c) || lower(@base,c);

        /// <summary>
        /// Determines whether a code represents a lowercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, LowerCased @case, C src)
            => SQ.lowerhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> represents a lowercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, LowerCased @case, char src)
            => test(@base, @case, (C)src);

        /// <summary>
        /// Determines whether a code represents an uppercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, UpperCased @case, C src)
            => SQ.upperhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> represents an uppercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, UpperCased @case, char src)
            => test(@base, @case, (C)src);

        /// <summary>
        /// Determines whether a code represents a hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, C src)
            => SQ.lowerhex(src) || SQ.upperhex(src);        

        [MethodImpl(Inline), Op]
        static bool contains(C min, C max, C src)
            => src >= min && src <= max;

    }
}