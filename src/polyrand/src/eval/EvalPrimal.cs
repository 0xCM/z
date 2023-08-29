//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public readonly partial struct EvalPrimal
{
    [MethodImpl(Inline), Op]
    public static CmpEval<char> eq(char a, char b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<string> eq(string a, string b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<byte> eq(byte a, byte b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<sbyte> eq(sbyte a, sbyte b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<short> eq(short a, short b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<ushort> eq(ushort a, ushort b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<int> eq(int a, int b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<uint> eq(uint a, uint b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<long> eq(long a, long b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<ulong> eq(ulong a, ulong b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<float> eq(float a, float b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<double> eq(double a, double b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<decimal> eq(decimal a, decimal b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<bool> eq(bool a, bool b)
        => EvalResults.eq(a, b, a == b);

    [MethodImpl(Inline), Op]
    public static CmpEval<char> gt(char a, char b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<byte> gt(byte a, byte b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<sbyte> gt(sbyte a, sbyte b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<short> gt(short a, short b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<ushort> gt(ushort a, ushort b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<int> gt(int a, int b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<uint> gt(uint a, uint b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<long> gt(long a, long b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<ulong> gt(ulong a, ulong b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<float> gt(float a, float b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<double> gt(double a, double b)
        => EvalResults.gt(a, b, a > b);

    [MethodImpl(Inline), Op]
    public static CmpEval<decimal> gt(decimal a, decimal b)
        => EvalResults.gt(a, b, a > b);
}
