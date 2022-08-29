//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using B = BinaryDigitFacets;
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
    }
}