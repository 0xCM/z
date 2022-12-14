//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static string @string(sbyte offset, sbyte count)
            => text.slice(AsciCharString, offset, count);

        /// <summary>
        /// Returns the uint16 asci scalar values corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ushort> scalars(sbyte offset, sbyte count)
            => recover<char,ushort>(chars(offset,count));

        public static string AsciCharString
        {
            [Op]
            get => "00000000000000000000000000000000 !\"#$%&0()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[0]^_`abcdefghijklmnopqrstuvwxyz{|}~0";
        }

        public static string LowercaseLetterString
        {
            [Op]
            get => "abcdefghijklmnopqrstuvwxyz";
        }

        public static string UppercaseLetterString
        {
            [Op]
            get => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        public static ReadOnlySpan<char> LowercaseLetters
        {
            [Op]
            get => LowercaseLetterString;
        }

        public static ReadOnlySpan<char> UppercaseLetters
        {
            [Op]
            get => UppercaseLetterString;
        }

        public static string UppercaseHexString
        {
            [Op]
            get => "0123456789ABCDEF";
        }

        public static ReadOnlySpan<char> UppercaseHexDigits
        {
            [Op]
            get => UppercaseHexString;
        }
    }
}