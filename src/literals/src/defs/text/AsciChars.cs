//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static AsciCode;

    using FA = AsciCodeFacets;
    using AK = AsciCode;
    using AT = AsciText;

    public readonly struct AsciChars
    {
        public const ushort CharByteCount = byte.MaxValue + 1;

        public const byte CodeByteCount = sbyte.MaxValue + 1;

        public static ReadOnlySpan<byte> CharBytes
            => new byte[CharByteCount]{
            0,0,     1,0,    2,0,     3,0,     4,0,     5,0,     6,0,     7,0,      // [2^0 - 1,    2^4 - 1]
            8,0,     9,0,    10,0,    11,0,    12,0,    13,0,    14,0,    15,0,     // [2^4,        2^5 - 1]
            16,0,    17,0,   18,0,    19,0,    20,0,    21,0,    22,0,    23,0,     // [2^5,        2^5 + 15]
            24,0,    25,0,   26,0,    27,0,    28,0,    29,0,    30,0,    31,0,     // [2^5 + 16,   2^6 - 1]
            32,0,    33,0,   34,0,    35,0,    36,0,    37,0,    38,0,    39,0,     // [2^6,        2^6 + 15]
            40,0,    41,0,   42,0,    43,0,    44,0,    45,0,    46,0,    47,0,     //
            48,0,    49,0,   50,0,    51,0,    52,0,    53,0,    54,0,    55,0,     //
            56,0,    57,0,   58,0,    59,0,    60,0,    61,0,    62,0,    63,0,     // [_,          2^7 - 1]
            64,0,    65,0,   66,0,    67,0,    68,0,    69,0,    70,0,    71,0,     // [2^7,        _]
            72,0,    73,0,   74,0,    75,0,    76,0,    77,0,    78,0,    79,0,     //
            80,0,    81,0,   82,0,    83,0,    84,0,    85,0,    86,0,    87,0,     //
            88,0,    89,0,   90,0,    91,0,    92,0,    93,0,    94,0,    95,0,     //
            96,0,    97,0,   98,0,    99,0,    100,0,   101,0,   102,0,   103,0,    //
            104,0,   105,0,  106,0,   107,0,   108,0,   109,0,   110,0,   111,0,    //
            112,0,   113,0,  114,0,   115,0,   116,0,   117,0,   118,0,   119,0,    //
            120,0,   121,0,  122,0,   123,0,   124,0,   125,0,   126,0,   127,0,    // [_,          2^8 - 1]
        };

        public static ReadOnlySpan<byte> CodeBytes
            => new byte[CodeByteCount]{
            0,   1,  2,   3,   4,   5,   6,   7,
            8,   9,  10,  11,  12,  13,  14,  15,
            16,  17, 18,  19,  20,  21,  22,  23,
            24,  25, 26,  27,  28,  29,  30,  31,
            32,  33, 34,  35,  36,  37,  38,  39,
            40,  41, 42,  43,  44,  45,  46,  47,
            48,  49, 50,  51,  52,  53,  54,  55,
            56,  57, 58,  59,  60,  61,  62,  63,
            64,  65, 66,  67,  68,  69,  70,  71,
            72,  73, 74,  75,  76,  77,  78,  79,
            80,  81, 82,  83,  84,  85,  86,  87,
            88,  89, 90,  91,  92,  93,  94,  95,
            96,  97, 98,  99,  100, 101, 102, 103,
            104, 105,106, 107, 108, 109, 110, 111,
            112, 113,114, 115, 116, 117, 118, 119,
            120, 121,122, 123, 124, 125, 126, 127,
        };

        public static ReadOnlySpan<char> DecimalDigits
            => AT.DecimalDigits;

        public static ReadOnlySpan<AsciCode> DecimalDigitCodes
            => new AsciCode[FA.DecimalDigitCount]{d0,d1,d2,d3,d4,d5,d6,d7,d8,d9};

        public static ReadOnlySpan<AsciCode> WhitespaceCodes
            => new AsciCode[6]{AK.Space, AK.NL, AK.CR, AK.FF, AK.Tab, AK.VTab};

        public static ReadOnlySpan<char> UpperLetters
            => AT.UpperLetters;

        public static ReadOnlySpan<AsciCode> UpperLetterCodes
            => new AsciCode[FA.UpperLetterCount]{A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z};

        public static ReadOnlySpan<char> LowerLetters
            => AT.LowerLetters;

        public static ReadOnlySpan<AsciCode> LowerLetterCodes
            => new AsciCode[FA.LowerLetterCount]{a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z};
    }
}