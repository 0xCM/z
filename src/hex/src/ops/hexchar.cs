//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static HexOptionData;

    partial class H0x
    {
        [MethodImpl(Inline)]
        public static char hexchar<T,C>(C @case, T src, byte pos)
            where T : unmanaged
            where C : unmanaged, ILetterCase
        {
            if(width<T>() == 8)
                return hexchar(@case, uint8(src), pos);
            else if(width<T>() == 16)
                return hexchar(@case, uint16(src), pos);
            else if(width<T>() == 32)
                return hexchar(@case, uint32(src), pos);
            else if(width<T>() == 64)
                return hexchar(@case, uint64(src), pos);
            else
                return default;
        }

        [MethodImpl(Inline)]
        public static char hexchar<C>(C @case, byte src, byte pos)
            where C : unmanaged, ILetterCase
        {
            if(typeof(C) == typeof(LowerCased))
                return hexchar(LowerCase, src, pos);
            else
                return hexchar(UpperCase, src, pos);
        }

        [MethodImpl(Inline)]
        public static char hexchar<C>(C @case, ushort src, byte pos)
            where C : unmanaged, ILetterCase
        {
            if(typeof(C) == typeof(LowerCased))
                return hexchar(LowerCase, src, pos);
            else
                return hexchar(UpperCase, src, pos);
        }

        [MethodImpl(Inline)]
        public static char hexchar<C>(C @case, uint src, byte pos)
            where C : unmanaged, ILetterCase
        {
            if(typeof(C) == typeof(LowerCased))
                return hexchar(LowerCase, src, pos);
            else
                return hexchar(UpperCase, src, pos);
        }

        [MethodImpl(Inline)]
        public static char hexchar<C>(C @case, ulong src, byte pos)
            where C : unmanaged, ILetterCase
        {
            if(typeof(C) == typeof(LowerCased))
                return hexchar(LowerCase, src, pos);
            else
                return hexchar(UpperCase, src, pos);
        }

        /// <summary>
        /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="case">The case specifier</param>
        /// <param name="value">The digit value</param>
        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, HexDigitValue value)
            => (char)symbol(@case, value);

        /// <summary>
        /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="case">The case specifier</param>
        /// <param name="value">The digit value</param>
        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, HexDigitValue value)
            => (char)symbol(@case, value);

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, byte value, byte pos)
            => (char)skip(first(LowerHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, ushort value, byte pos)
            => (char)skip(first(LowerHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, uint value, byte pos)
            => (char)skip(first(LowerHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, ulong value, byte pos)
            => (char)skip(first(LowerHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, byte value, byte pos)
            => (char)skip(first(UpperHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, ushort value, byte pos)
            => (char)skip(first(UpperHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, uint value, byte pos)
            => (char)skip(first(UpperHexDigits), (byte)(0xF & (byte)(value >> pos*4)));

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, ulong value, byte pos)
            => (char)skip(first(UpperHexDigits), (byte)(0xF & (byte)(value >> pos*4)));
    }
}