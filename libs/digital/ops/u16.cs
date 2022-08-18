//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        /// <summary>
        /// Converts a binary character to the number it represents
        /// </summary>
        /// <param name="c">The digit character</param>
        [MethodImpl(Inline), Op]
        public static ushort u16(Base2 @base, char c)
            => (ushort)digit(@base, c);

        /// <summary>
        /// Converts an octal character to the number it represents
        /// </summary>
        /// <param name="c">The digit character</param>
        [MethodImpl(Inline), Op]
        public static ushort u16(Base8 @base, char c)
            => (ushort)digit(@base, c);

        /// <summary>
        /// Converts a decimal character to the number it represents
        /// </summary>
        /// <param name="c">The digit character</param>
        [MethodImpl(Inline), Op]
        public static ushort u16(Base10 @base, char c)
            => (ushort)digit(@base, c);

        /// <summary>
        /// Converts a hex character to number it represents
        /// </summary>
        /// <param name="c">The digit character</param>
        [MethodImpl(Inline), Op]
        public static ushort u16(Base16 @base, char c)
            => (ushort)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static ushort u16(Base16 @base, UpperCased @case, char c)
            => (ushort)digit(@base, @case, c);

        [MethodImpl(Inline), Op]
        public static ushort u16(Base16 @base, LowerCased @case, char c)
            => (ushort)digit(@base, @case, c);
    }
}