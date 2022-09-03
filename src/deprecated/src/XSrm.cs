//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public static unsafe class XSrm
    {
        public static void GetBits(this decimal value, out bool isNegative, out byte scale, out uint low, out uint mid, out uint high)
        {
            int[] bits = decimal.GetBits(value);

            // The return value is a four-element array of 32-bit signed integers.
            // The first, second, and third elements of the returned array contain the low, middle, and high 32 bits of the 96-bit integer number.
            low = unchecked((uint)bits[0]);
            mid = unchecked((uint)bits[1]);
            high = unchecked((uint)bits[2]);

            // The fourth element of the returned array contains the scale factor and sign. It consists of the following parts:
            // Bits 0 to 15, the lower word, are unused and must be zero.
            // Bits 16 to 23 must contain an exponent between 0 and 28, which indicates the power of 10 to divide the integer number.
            // Bits 24 to 30 are unused and must be zero.
            // Bit 31 contains the sign; 0 meaning positive, and 1 meaning negative.
            scale = unchecked((byte)(bits[3] >> 16));
            isNegative = (bits[3] & 0x80000000) != 0;
        }

        [MethodImpl(Inline), Op]
        public static void WriteBytes(this byte[] buffer, int start, byte value, int byteCount)
        {
            ref var src = ref first(buffer);
            fixed (byte* pSrc = &src)
            {
                byte* pStart = pSrc + start;
                for (int i = 0; i<byteCount; i++)
                    seek(pStart, i) = value;
            }
        }

        [MethodImpl(Inline), Op]
        public static void WriteDouble(this byte[] buffer, int start, double value)
            => WriteUInt64(buffer, start, *(ulong*)&value);

        [MethodImpl(Inline), Op]
        public static void WriteSingle(this byte[] buffer, int start, float value)
            => WriteUInt32(buffer, start, *(uint*)&value);

        [MethodImpl(Inline), Op]
        public static void WriteUInt32(this byte[] buffer, int start, uint value)
        {
            ref var dst = ref seek(buffer, start);
            seek(dst,0) = (byte)value;
            seek(dst,1) = (byte)(value >> 8);
            seek(dst,2) = (byte)(value >> 16);
            seek(dst,3) = (byte)(value >> 24);
        }

        [MethodImpl(Inline), Op]
        public static void WriteByte(this byte[] buffer, int start, byte value)
            => seek(buffer,start) = value;

        [MethodImpl(Inline), Op]
        public static void WriteUInt16(this byte[] buffer, int start, ushort value)
        {
            ref var dst = ref seek(buffer, start);
            seek(dst,0) = (byte)value;
            seek(dst,1) = (byte)(value >> 8);
        }

        [MethodImpl(Inline), Op]
        public static void WriteUInt16BE(this byte[] buffer, int start, ushort value)
        {
            fixed (byte* ptr = &buffer[start])
            {
                unchecked
                {
                    ptr[0] = (byte)(value >> 8);
                    ptr[1] = (byte)value;
                }
            }
        }

        [MethodImpl(Inline), Op]
        public static void WriteUInt32BE(this byte[] buffer, int start, uint value)
        {
            fixed (byte* ptr = &buffer[start])
            {
                unchecked
                {
                    ptr[0] = (byte)(value >> 24);
                    ptr[1] = (byte)(value >> 16);
                    ptr[2] = (byte)(value >> 8);
                    ptr[3] = (byte)value;
                }
            }
        }

        [MethodImpl(Inline), Op]
        public static void WriteUInt64(this byte[] buffer, int start, ulong value)
        {
            WriteUInt32(buffer, start, unchecked((uint)value));
            WriteUInt32(buffer, start + 4, unchecked((uint)(value >> 32)));
        }

        public const int SizeOfSerializedDecimal = sizeof(byte) + 3 * sizeof(uint);

        public static void WriteDecimal(this byte[] buffer, int start, decimal value)
        {
            bool isNegative;
            byte scale;
            uint low, mid, high;
            value.GetBits(out isNegative, out scale, out low, out mid, out high);

            buffer.WriteByte(start, (byte)(scale | (isNegative ? 0x80 : 0x00)));
            WriteUInt32(buffer, start + 1, low);
            WriteUInt32(buffer, start + 5, mid);
            WriteUInt32(buffer, start + 9, high);
        }

        public const int SizeOfGuid = 16;

        [Op]
        public static void WriteGuid(this byte[] buffer, int start, Guid value)
        {
            fixed (byte* dst = &buffer[start])
            {
                byte* src = (byte*)&value;

                uint a = *(uint*)(src + 0);
                unchecked
                {
                    dst[0] = (byte)a;
                    dst[1] = (byte)(a >> 8);
                    dst[2] = (byte)(a >> 16);
                    dst[3] = (byte)(a >> 24);

                    ushort b = *(ushort*)(src + 4);
                    dst[4] = (byte)b;
                    dst[5] = (byte)(b >> 8);

                    ushort c = *(ushort*)(src + 6);
                    dst[6] = (byte)c;
                    dst[7] = (byte)(c >> 8);
                }

                dst[8] = src[8];
                dst[9] = src[9];
                dst[10] = src[10];
                dst[11] = src[11];
                dst[12] = src[12];
                dst[13] = src[13];
                dst[14] = src[14];
                dst[15] = src[15];
            }
        }

        [Op]
        public static void WriteUTF8(this byte[] buffer, int start, char* charPtr, int charCount, int byteCount, bool allowUnpairedSurrogates)
        {
            Debug.Assert(byteCount >= charCount);
            const char ReplacementCharacter = '\uFFFD';

            char* strEnd = charPtr + charCount;
            fixed (byte* bufferPtr = &buffer[0])
            {
                byte* ptr = bufferPtr + start;

                if (byteCount == charCount)
                {
                    while (charPtr < strEnd)
                    {
                        Debug.Assert(*charPtr <= 0x7f);
                        *ptr++ = unchecked((byte)*charPtr++);
                    }
                }
                else
                {
                    while (charPtr < strEnd)
                    {
                        char c = *charPtr++;

                        if (c < 0x80)
                        {
                            *ptr++ = (byte)c;
                            continue;
                        }

                        if (c < 0x800)
                        {
                            ptr[0] = (byte)(((c >> 6) & 0x1F) | 0xC0);
                            ptr[1] = (byte)((c & 0x3F) | 0x80);
                            ptr += 2;
                            continue;
                        }

                        if (IsSurrogateChar(c))
                        {
                            // surrogate pair
                            if (IsHighSurrogateChar(c) && charPtr < strEnd && IsLowSurrogateChar(*charPtr))
                            {
                                int highSurrogate = c;
                                int lowSurrogate = *charPtr++;
                                int codepoint = (((highSurrogate - 0xd800) << 10) + lowSurrogate - 0xdc00) + 0x10000;
                                ptr[0] = (byte)(((codepoint >> 18) & 0x7) | 0xF0);
                                ptr[1] = (byte)(((codepoint >> 12) & 0x3F) | 0x80);
                                ptr[2] = (byte)(((codepoint >> 6) & 0x3F) | 0x80);
                                ptr[3] = (byte)((codepoint & 0x3F) | 0x80);
                                ptr += 4;
                                continue;
                            }

                            // unpaired high/low surrogate
                            if (!allowUnpairedSurrogates)
                            {
                                c = ReplacementCharacter;
                            }
                        }

                        ptr[0] = (byte)(((c >> 12) & 0xF) | 0xE0);
                        ptr[1] = (byte)(((c >> 6) & 0x3F) | 0x80);
                        ptr[2] = (byte)((c & 0x3F) | 0x80);
                        ptr += 3;
                    }
                }

                Debug.Assert(ptr == bufferPtr + start + byteCount);
                Debug.Assert(charPtr == strEnd);
            }
        }

        [Op]
        public static unsafe int GetUTF8ByteCount(string str)
        {
            fixed (char* ptr = str)
                return GetUTF8ByteCount(ptr, str.Length);
        }

        [Op]
        public static unsafe int GetUTF8ByteCount(char* str, int charCount)
        {
            char* remainder;
            return GetUTF8ByteCount(str, charCount, int.MaxValue, out remainder);
        }

        [Op]
        public static int GetUTF8ByteCount(char* str, int charCount, int byteLimit, out char* remainder)
        {
            char* end = str + charCount;

            char* ptr = str;
            int byteCount = 0;
            while (ptr < end)
            {
                int characterSize;
                char c = *ptr++;
                if (c < 0x80)
                {
                    characterSize = 1;
                }
                else if (c < 0x800)
                {
                    characterSize = 2;
                }
                else if (IsHighSurrogateChar(c) && ptr < end && IsLowSurrogateChar(*ptr))
                {
                    // surrogate pair:
                    characterSize = 4;
                    ptr++;
                }
                else
                {
                    characterSize = 3;
                }

                if (byteCount + characterSize > byteLimit)
                {
                    ptr -= (characterSize < 4) ? 1 : 2;
                    break;
                }

                byteCount += characterSize;
            }

            remainder = ptr;
            return byteCount;
        }

        [MethodImpl(Inline), Op]
        public static bool IsSurrogateChar(int c)
            => unchecked((uint)(c - 0xD800)) <= 0xDFFF - 0xD800;

        [MethodImpl(Inline), Op]
        public static bool IsHighSurrogateChar(int c)
            => unchecked((uint)(c - 0xD800)) <= 0xDBFF - 0xD800;

        [MethodImpl(Inline), Op]
        public static bool IsLowSurrogateChar(int c)
            => unchecked((uint)(c - 0xDC00)) <= 0xDFFF - 0xDC00;

        [MethodImpl(Inline), Op]
        public static Outcome ValidateRange(int bufferLength, int start, int byteCount, string byteCountParameterName)
        {
            if (start < 0 || start > bufferLength)
            {
                return (false, "RangeError");
            }

            if (byteCount < 0 || byteCount > bufferLength - start)
            {
                return (false, "RangeError");
            }

            return true;
        }

        [MethodImpl(Inline), Op]
        public static int GetUserStringByteLength(int characterCount)
        {
            return characterCount * 2 + 1;
        }

        [Op]
        public static byte GetUserStringTrailingByte(string str)
        {
            // ECMA-335 II.24.2.4:
            // This final byte holds the value 1 if and only if any UTF16 character within
            // the string has any bit set in its top byte, or its low byte is any of the following:
            // 0x01-0x08, 0x0E-0x1F, 0x27, 0x2D, 0x7F.  Otherwise, it holds 0.
            // The 1 signifies Unicode characters that require handling beyond that normally provided for 8-bit encoding sets.

            foreach (char ch in str)
            {
                if (ch >= 0x7F)
                {
                    return 1;
                }

                switch ((int)ch)
                {
                    case 0x1:
                    case 0x2:
                    case 0x3:
                    case 0x4:
                    case 0x5:
                    case 0x6:
                    case 0x7:
                    case 0x8:
                    case 0xE:
                    case 0xF:
                    case 0x10:
                    case 0x11:
                    case 0x12:
                    case 0x13:
                    case 0x14:
                    case 0x15:
                    case 0x16:
                    case 0x17:
                    case 0x18:
                    case 0x19:
                    case 0x1A:
                    case 0x1B:
                    case 0x1C:
                    case 0x1D:
                    case 0x1E:
                    case 0x1F:
                    case 0x27:
                    case 0x2D:
                        return 1;
                }
            }

            return 0;
        }
    }
}