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
    }
}