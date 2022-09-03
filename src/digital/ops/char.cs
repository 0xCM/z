//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        /// <summary>
        /// Computes the symbolic representation of a <see cref='BinaryDigitValue'/>
        /// </summary>
        /// <param name="src">The source digit</param>
        [MethodImpl(Inline), Op]
        public static char @char(BinaryDigitValue src)
            => (char)symbol(src);

        /// <summary>
        /// Computes the symbolic representation of a <see cref='OctalDigitValue'/>
        /// </summary>
        /// <param name="src">The source digit</param>
        [MethodImpl(Inline), Op]
        public static char @char(OctalDigitValue src)
            => (char)symbol(src);

        /// <summary>
        /// Computes the symbolic representation of a <see cref='DecimialDigitValue'/>
        /// </summary>
        /// <param name="src">The source digit</param>
        [MethodImpl(Inline), Op]
        public static char @char(DecimalDigitValue src)
            => (char)symbol(src);

        /// <summary>
        /// Computes the symbolic representation of a <see cref='HexDigitValue'/> chosen from [0..9] and [A..F]
        /// </summary>
        /// <param name="case">The case selector</param>
        /// <param name="src">The source digit</param>
        [MethodImpl(Inline), Op]
        public static char @char(UpperCased @case, HexDigitValue src)
            => Hex.hexchar(@case,src);

        /// <summary>
        /// Computes the symbolic representation of a <see cref='HexDigitValue'/> chosen from [0..9] and [a..f]
        /// </summary>
        /// <param name="case">The case selector</param>
        /// <param name="src">The source digit</param>
        [MethodImpl(Inline), Op]
        public static char @char(LowerCased @case, HexDigitValue src)
            => Hex.hexchar(@case,src);
    }
}