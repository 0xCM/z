//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static HexConst;

[ApiComplete]
public readonly struct CpuBytes
{
    public static ReadOnlySpan<byte> Units128x8u
        => new byte[16]{
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
            };

    public static ReadOnlySpan<byte> Units128x16u
        => new byte[16]{
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0
            };

    public static ReadOnlySpan<byte> Units128x32u
        => new byte[16]{
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0
            };

    public static ReadOnlySpan<byte> Units128x64u
        => new byte[16]{
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0
            };

    public static ReadOnlySpan<byte> Units256x8u
        => new byte[32]{
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
            };

    public static ReadOnlySpan<byte> Units256x16u
        => new byte[32]{
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0
            };

    public static ReadOnlySpan<byte> Units256x32u
        => new byte[32]{
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0
            };

    public static ReadOnlySpan<byte> Units256x64u
        => new byte[32]{
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0
            };

    public static ReadOnlySpan<byte> Units512x8u
        => new byte[64]{
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            };

    public static ReadOnlySpan<byte> Units512x16u
        => new byte[64]{
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,
            1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,
            };

    public static ReadOnlySpan<byte> Units512x32u
        => new byte[64]{
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,
            1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,
            };

    public static ReadOnlySpan<byte> Units512x64u
        => new byte[64]{
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            };

    public static ReadOnlySpan<byte> Inc128x8u
        => new byte[16]{0,1,2,3,4,5,6,7,8,9,10,B,12,13,14,F};

    public static ReadOnlySpan<byte> Inc128x16u
        => new byte[16]{0,0,1,0,2,0,3,0,4,0,5,0,6,0,7,0};

    public static ReadOnlySpan<byte> Inc128x32u
        => new byte[16]{0,0,0,0,1,0,0,0,2,0,0,0,3,0,0,0};

    public static ReadOnlySpan<byte> Inc128x64u
        => new byte[16]{0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0};

    public static ReadOnlySpan<byte> Inc256x8u
        => new byte[32]{
            0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
            16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31
            };

    public static ReadOnlySpan<byte> Inc256x16u
        => new byte[32]{
            0,0,1,0,2,0,3,0,4,0,5,0,6,0,7,0,
            8,0,9,0,10,0,11,0,12,0,13,0,14,0,15,0
            };

    public static ReadOnlySpan<byte> Inc256x32u
        => new byte[32]{
            0,0,0,0,1,0,0,0,2,0,0,0,3,0,0,0,
            4,0,0,0,5,0,0,0,6,0,0,0,7,0,0,0
            };

    public static ReadOnlySpan<byte> Inc256x64u
        => new byte[32]{
            0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            2,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0
            };


    /// <summary>
    /// Defines a mask for an even 256x8-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Even_256x8
        => new byte[32]{
            0,FF,0,FF,0,FF,0,FF,
            0,FF,0,FF,0,FF,0,FF,
            0,FF,0,FF,0,FF,0,FF,
            0,FF,0,FF,0,FF,0,FF,
        };

    /// <summary>
    /// Defines a mask for an even 256x8-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Odd_256x8
        => new byte[32]{
            FF,0,FF,0,FF,0,FF,0,
            FF,0,FF,0,FF,0,FF,0,
            FF,0,FF,0,FF,0,FF,0,
            FF,0,FF,0,FF,0,FF,0,
        };

    /// <summary>
    /// Defines a mask for an even 256x8-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Even_256x16
        => new byte[32]{
            0,0,FF,FF,0,0,FF,FF,
            0,0,FF,FF,0,0,FF,FF,
            0,0,FF,FF,0,0,FF,FF,
            0,0,FF,FF,0,0,FF,FF,
        };

    /// <summary>
    /// Defines a mask for an odd 256x32-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Odd_256x16
        => new byte[32]{
            FF,FF,0,0,FF,FF,0,0,
            FF,FF,0,0,FF,FF,0,0,
            FF,FF,0,0,FF,FF,0,0,
            FF,FF,0,0,FF,FF,0,0,
        };

    /// <summary>
    /// Defines a mask for an even 256x32-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Even_256x32
        => new byte[32]{
            0,0,0,0, FF,FF,FF,FF,
            0,0,0,0, FF,FF,FF,FF,
            0,0,0,0, FF,FF,FF,FF,
            0,0,0,0, FF,FF,FF,FF,
        };

    /// <summary>
    /// Defines a mask for an odd 256x32-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Odd_256x32
        => new byte[32]{
            FF,FF,FF,FF,0,0,0,0,
            FF,FF,FF,FF,0,0,0,0,
            FF,FF,FF,FF,0,0,0,0,
            FF,FF,FF,FF,0,0,0,0,
        };

    /// <summary>
    /// Defines a mask for an even 256x64-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Even_256x64
        => new byte[32]{
            0,0,0,0,0,0,0,0,
            FF,FF,FF,FF,FF,FF,FF,FF,
            0,0,0,0,0,0,0,0,
            FF,FF,FF,FF,FF,FF,FF,FF,
        };

    /// <summary>
    /// Defines a mask for an odd 256x64-bit blend
    /// </summary>
    public static ReadOnlySpan<byte> BlendSpec_Odd_256x64
        => new byte[32]{
            FF,FF,FF,FF,FF,FF,FF,FF,
            0,0,0,0,0,0,0,0,
            FF,FF,FF,FF,FF,FF,FF,FF,
            0,0,0,0,0,0,0,0,
        };


    /// <summary>
    /// Shuffle pattern that, when applied, swaps the byte-level representation of 16-bit unsigned integers
    /// </summary>
    public static ReadOnlySpan<byte> ByteSwap128x16u
        => new byte[16]{1,0,3,2,5,4,7,6,9,8,B,A,D,C,F,E};

    /// <summary>
    /// Shuffle pattern that, when applied, swaps the byte-level representation of 32-bit unsigned integers
    /// </summary>
    public static ReadOnlySpan<byte> ByteSwap128x32u
        => new byte[16]{
            3,2,1,0,7,6,5,4,B,A,9,8,F,E,D,C
            };

    /// <summary>
    /// Shuffle pattern that, when applied, swaps the byte-level representation of 64-bit unsigned integers
    /// </summary>
    public static ReadOnlySpan<byte> ByteSwap128x64u
        => new byte[16]{
            7,6,5,4,3,2,1,0,F,E,D,C,B,A,9,8
            };

    /// <summary>
    /// Shuffle pattern that, when applied, swaps the byte-level representation of 16-bit unsigned integers
    /// </summary>
    public static ReadOnlySpan<byte> ByteSwap256x16u
        => new byte[32]{
            1,0,3,2,5,4,7,6,9,8,B,A,D,C,F,E,
            1,0,3,2,5,4,7,6,9,8,B,A,D,C,F,E
            };

    /// <summary>
    /// Shuffle pattern that, when applied, swaps the byte-level representation of 32-bit unsigned integers
    /// </summary>
    public static ReadOnlySpan<byte> ByteSwap256x32u
        => new byte[32]{
            3,2,1,0,7,6,5,4,B,A,9,8,F,E,D,C,
            3,2,1,0,7,6,5,4,B,A,9,8,F,E,D,C
            };


    /// <summary>
    /// Shuffle pattern that, when applied, swaps the byte-level representation of 64-bit unsigned integers
    /// </summary>
    public static ReadOnlySpan<byte> ByteSwap256x64u
        => new byte[32]{
            7,6,5,4,3,2,1,0,F,E,D,C,B,A,9,8,
            7,6,5,4,3,2,1,0,F,E,D,C,B,A,9,8
            };

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content rightward by 48 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotR48_128x8u
        => new byte[16]{6,7,8,9,A,B,C,E,E,F,0,1,2,4,5,6};

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content rightward by 8 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotR8_128x8u
        => new byte[16]{1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,0};

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content rightward by 16 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotR16_128x8u
        => new byte[16]{2,3,4,5,6,7,8,9,A,B,C,D,E,F,0,1};

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content rightward by 24 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotR24_128x8u
        => new byte[16]{3,4,5,6,7,8,9,A,B,C,D,E,F,0,1,2};

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content rightward by 32 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotR32_128x8u
        => new byte[16]{4,5,6,7,8,9,A,B,C,D,E,F,0,1,2,4};

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content rightward by 40 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotR40_128x8u
        => new byte[16]{5,6,7,8,9,A,B,C,D,E,F,0,1,2,4,5};


    public static ReadOnlySpan<byte> PackUSLo16x128x8u
        => new byte[16]{
            0, 2, 4, 6, 8, 10,12,14,
            FF,FF,FF,FF,FF,FF,FF,FF
            };

    public static ReadOnlySpan<byte> PackUSLo32x128x16u
        => new byte[16]{
            0,1, 4,5, 8,9, 12,13,
            FF,FF,FF,FF,FF,FF,FF,FF
            };

    public static ReadOnlySpan<byte> PackUSLo16x256x8u
        => new byte[32]{
            0, 2, 4, 6, 8, 10,12,14,
            FF,FF,FF,FF,FF,FF,FF,FF,
            0, 2, 4, 6, 8, 10,12,14,
            FF,FF,FF,FF,FF,FF,FF,FF
            };

    public static ReadOnlySpan<byte> PackUSLo32x256x16u
        => new byte[32]{
            0,1,4,5,8,9,12,13,
            FF,FF,FF,FF,FF,FF,FF,FF,
            0,1,4,5,8,9,12,13,
            FF,FF,FF,FF,FF,FF,FF,FF,
            };

    public static ReadOnlySpan<byte> PackUSHi16x128x8u
        => new byte[16]{
            FF,FF,FF,FF,FF,FF,FF,FF,
            0, 2, 4, 6, 8, 10,12,14,
            };

    public static ReadOnlySpan<byte> PackUSHi32x128x16u
        => new byte[16]{
            FF,FF,FF,FF,FF,FF,FF,FF,
            0,1,4,5,8,9,12,13
            };

    public static ReadOnlySpan<byte> PackUSHi16x256x8u
        => new byte[32]{
            FF,FF,FF,FF,FF,FF,FF,FF,
            0, 2, 4, 6, 8, 10,12,14,
            FF,FF,FF,FF,FF,FF,FF,FF,
            0, 2, 4, 6, 8, 10,12,14,
            };

    public static ReadOnlySpan<byte> PackUSHi32x256x16u
        => new byte[32]{
            FF,FF,FF,FF,FF,FF,FF,FF,
            0, 1, 4, 5, 8, 9, 12,13,
            FF,FF,FF,FF,FF,FF,FF,FF,
            0,1,4,5,8,9,12,13
            };

    public static ReadOnlySpan<byte> Dec128x8u
        => new byte[16]{F,E,D,C,B,A,9,8,7,6,5,4,3,2,1,0};

    public static ReadOnlySpan<byte> Dec128x16u
        => new byte[16]{7,0,6,0,5,0,4,0,3,0,2,0,1,0,0,0};

    public static ReadOnlySpan<byte> Dec128x32u
        => new byte[16]{3,0,0,0,2,0,0,0,1,0,0,0,0,0,0,0};

    public static ReadOnlySpan<byte> Dec128x64u
        => new byte[16]{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    public static ReadOnlySpan<byte> Dec256x8u
        => new byte[32]{
            31,30,29,28,27,26,25,24,23,22,21,20,19,18,17,16,
            15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0
            };

    public static ReadOnlySpan<byte> Dec256x16u
        => new byte[32]{
            15,0,14,0,13,0,12,0,11,0,10,0,9,0,8,0,
            7,0,6,0,5,0,4,0,3,0,2,0,1,0,0,0
            };

    public static ReadOnlySpan<byte> Dec256x32u
        => new byte[32]{
            7,0,0,0,6,0,0,0,5,0,0,0,4,0,0,0,
            3,0,0,0,2,0,0,0,1,0,0,0,0,0,0,0
            };

    public static ReadOnlySpan<byte> Dec256x64u
        => new byte[32]{
            3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,
            1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
            };


    public static ReadOnlySpan<byte> LaneMerge256x8u
        => new byte[32]{
            00,02,04,06,08,10,12,14,
            16,18,20,22,24,26,28,30,
            01,03,05,07,09,11,13,15,
            17,19,21,23,25,27,29,31};

    public static ReadOnlySpan<byte> LaneMerge256x16u
        => new byte[32]{
            0x00,0x00,0x02,0x00,0x04,0x00,0x06,0x00,
            0x08,0x00,0x0A,0x00,0x0C,0x00,0x0E,0x00,
            0x01,0x00,0x03,0x00,0x05,0x00,0x07,0x00,
            0x09,0x00,0x0B,0x00,0x0D,0x00,0x0F,0x00};


    public static ReadOnlySpan<byte> Inc512x8u
        => new byte[64]{
            0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
            16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,
            32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,
            48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63
            };

    public static ReadOnlySpan<byte> Inc512x16u
        => new byte[64]{
            0,0,1,0,2,0,3,0,4,0,5,0,6,0,7,0,
            8,0,9,0,10,0,11,0,12,0,13,0,14,0,15,0,
            16,0,17,0,18,0,19,0,20,0,21,0,22,0,23,0,
            24,0,25,0,26,0,27,0,28,0,29,0,30,0,31,0
            };

    public static ReadOnlySpan<byte> Inc512x32u
        => new byte[64]{
            0,0,0,0,1,0,0,0,2,0,0,0,3,0,0,0,
            4,0,0,0,5,0,0,0,6,0,0,0,7,0,0,0,
            8,0,0,0,9,0,0,0,A,0,0,0,B,0,0,0,
            C,0,0,0,D,0,0,0,E,0,0,0,F,0,0,0
            };

    public static ReadOnlySpan<byte> Inc512x64u
        => new byte[64]{
            0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,
            2,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,
            4,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,
            6,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,
            };

    public static ReadOnlySpan<byte> ClearAlt256x8u
        => new byte[32]{0x00,0xff,0x02,0xff,0x04,0xff,0x06,0xff,0x08,0xff,0x0a,0xff,0x0c,0xff,0x0e,0xff,0x00,0xff,0x02,0xff,0x04,0xff,0x06,0xff,0x08,0xff,0x0a,0xff,0x0c,0xff,0x0e,0xff};

    public static ReadOnlySpan<byte> ClearAlt256x16u
        => new byte[32]{0x00,0x00,0xff,0xff,0x02,0x00,0xff,0xff,0x04,0x00,0xff,0xff,0x06,0x00,0xff,0xff,0x00,0x00,0xff,0xff,0x02,0x00,0xff,0xff,0x04,0x00,0xff,0xff,0x06,0x00,0xff,0xff};
}
