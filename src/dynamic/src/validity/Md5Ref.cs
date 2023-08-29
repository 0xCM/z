//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Defines MD5-related operations
/// </summary>
/// <remarks>
/// References:
/// https://en.wikipedia.org/wiki/MD5
/// https://referencesource.microsoft.com/#System.Workflow.Runtime/MD5HashHelper.cs,5a97802b6014fccc,references
/// </remarks>
[ApiHost("alg.md5")]
public readonly partial struct Md5Ref
{
    /*
        for i from 0 to 63 do
            K[i] := floor(2^32 × abs (sin(i + 1)))
        end for
    */

    [MethodImpl(Inline), Op]
    internal static void sines(Span<uint> dst)
    {
        for(var i=0; i<64; i++)
            seek(dst,i) = (uint)fmath.floor((double)Pow2.T32 * fmath.abs(fmath.sin((double)i + 1)));
    }

    [Op]
    internal static Span<uint> sines()
    {
        var dst = alloc<uint>(64);
        sines(dst);
        return dst;
    }

    /// <summary>
    /// The reference implementation given in https://referencesource.microsoft.com/#System.Workflow.Runtime/MD5HashHelper.cs,5a97802b6014fccc,references
    /// </summary>
    /// <param name="buffer">The source data</param>
    [Op]
    public static byte[] calc(byte[] buffer)
    {
        int blocks = (buffer.Length + 8) / 64 + 1;

        uint aa = 0x67452301;
        uint bb = 0xefcdab89;
        uint cc = 0x98badcfe;
        uint dd = 0x10325476;

        for (int i = 0; i < blocks; i++)
        {
            byte[] block = buffer;
            int offset = i * 64;

            if (offset + 64 > buffer.Length)
            {
                block = new byte[64];

                for (int j = offset; j < buffer.Length; j++)
                {
                    block[j - offset] = buffer[j];
                }
                if (offset <= buffer.Length)
                {
                    block[buffer.Length - offset] = 0x80;
                }
                if (i == blocks - 1)
                {
                    block[56] = (byte)(buffer.Length << 3);
                    block[57] = (byte)(buffer.Length >> 5);
                    block[58] = (byte)(buffer.Length >> 13);
                    block[59] = (byte)(buffer.Length >> 21);
                }

                offset = 0;
            }

            uint a = aa;
            uint b = bb;
            uint c = cc;
            uint d = dd;

            uint f;
            int g;

            for (int j = 0; j < 64; j++)
            {
                if (j < 16)
                {
                    f = b & c | ~b & d;
                    g = j;
                }
                else if (j < 32)
                {
                    f = b & d | c & ~d;
                    g = 5 * j + 1;
                }
                else if (j < 48)
                {
                    f = b ^ c ^ d;
                    g = 3 * j + 5;
                }
                else
                {
                    f = c ^ (b | ~d);
                    g = 7 * j;
                }

                g = (g & 0x0f) * 4 + offset;

                uint hold = d;
                d = c;
                c = b;

                b = a + f + SinesTable[j] + (uint)(block[g] + (block[g + 1] << 8) + (block[g + 2] << 16) + (block[g + 3] << 24));
                b = b << ShiftTable[j & 3 | j >> 2 & ~3] | b >> 32 - ShiftTable[j & 3 | j >> 2 & ~3];
                b += c;

                a = hold;
            }

            aa += a;
            bb += b;
            cc += c;
            dd += d;
        }

        return new byte[] {
            (byte)aa, (byte)(aa >> 8), (byte)(aa >> 16), (byte)(aa >> 24),
            (byte)bb, (byte)(bb >> 8), (byte)(bb >> 16), (byte)(bb >> 24),
            (byte)cc, (byte)(cc >> 8), (byte)(cc >> 16), (byte)(cc >> 24),
            (byte)dd, (byte)(dd >> 8), (byte)(dd >> 16), (byte)(dd >> 24) };
    }

    public static ReadOnlySpan<byte> InputData
        => new byte[67]{0x57,0x56,0x53,0x48,0x83,0xec,0x20,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x49,0x8b,0xd8,0x48,0x8b,0xce,0x48,0x8b,0xd7,0x4c,0x8b,0xc3,0xe8,0x22,0xaa,0x45,0xff,0x48,0x8b,0xce,0x48,0x8b,0xd7,0x4c,0x8b,0xc3,0xe8,0x1c,0xaa,0x45,0xff,0x48,0x8b,0xce,0x48,0x8b,0xd7,0x4c,0x8b,0xc3,0xe8,0x16,0xaa,0x45,0xff,0x90,0x48,0x83,0xc4,0x20,0x5b,0x5e,0x5f,0xc3};

    public static ReadOnlySpan<byte> OutputHash
        => new byte[16]{0x63,0x81,0x8d,0xcb,0x85,0x35,0xc9,0xde,0x13,0x9e,0x2d,0x74,0x34,0x64,0xf5,0x8f};

    internal static int[] ShiftTable
        = new int[] { 7, 12, 17, 22, 5, 9, 14, 20, 4, 11, 16, 23, 6, 10, 15, 21 };

    internal static uint[] SinesTable = new uint[] {
        0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee, 0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
        0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be, 0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,

        0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa, 0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
        0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed, 0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,

        0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c, 0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
        0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05, 0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,

        0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039, 0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
        0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1, 0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391 };
}
