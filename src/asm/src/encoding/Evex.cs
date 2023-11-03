//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public class Evex
{
    [MethodImpl(Inline)]
    public static bit test(ReadOnlySpan<byte> src)
    {
        if(src.Length < 4)
            return false;
        else
            return first(src) == 0x62;
    }

    [MethodImpl(Inline)]
    public static EvexPrefix prefix(byte b1, byte b2, byte b3)
        => new (Bytes.join(0x62, b1, b2, b3));

    [MethodImpl(Inline)]
    public static EvexPrefix prefix(ReadOnlySpan<byte> src)
    {
        if(src.Length < 4)
            return EvexPrefix.Empty;
        else
            return @as<EvexPrefix>(src);
    }

    const string vvvv = "vvvv";

    const string mmm = "mmm";

    const string W = "W";

    const string R = "R";

    const string X = "X";

    const string B = "B";

    const string RXB = $"{R}{X}{B}";

    const string pp = "pp";

    const string aaa = "aaa";

    const string q = "q";

    const string d0 = "0";

    const string d1 = "1";

    const string z = "z";

    const string b = "b";

    const string f = "f";

    const string VL = "VL";

    const string EvexIndicator = "01100010";

    public static readonly BpInfo Pattern = BitPatterns.describe(nameof(Evex),
        EvexIndicator,
        mmm, d0, q, RXB,
        W, vvvv, d1, pp, 
        z,  VL, b, f, aaa 
        );
}