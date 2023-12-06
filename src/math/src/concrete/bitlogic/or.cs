//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static sbyte or(sbyte a, sbyte b)
        => (sbyte)(a | b);

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static sbyte or(sbyte a, sbyte b, sbyte c)
        => (sbyte)((int)a | (int)b | (int)c);

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    /// <param name="d">The fourth operand</param>
    [MethodImpl(Inline), Op]
    public static sbyte or(sbyte a, sbyte b, sbyte c, sbyte d)
        => (sbyte)((int)a | (int)b | (int)c | (int)d);

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static byte or(byte a, byte b)
        => (byte)(a | b);

    [MethodImpl(Inline), Op]
    public static byte or(byte a, byte b, byte c)
        => (byte)((uint)a | (uint)b | (uint)c);

    [MethodImpl(Inline), Op]
    public static byte or(byte a, byte b, byte c, byte d)
        => (byte)((uint)a | (uint)b | (uint)c | (uint)d);

    [MethodImpl(Inline), Op]
    public static byte or(byte a, byte b, byte c, byte d, byte e)
        => (byte)(a | b | c | d | e);

    [MethodImpl(Inline), Op]
    public static byte or(byte a, byte b, byte c, byte d, byte e, byte f)
        => (byte)(a | b | c | d | e | f);

    [MethodImpl(Inline), Op]
    public static byte or(byte a, byte b, byte c, byte d, byte e, byte f, byte g)
        => (byte)(a | b | c | d | e | f | g);

    [MethodImpl(Inline), Op]
    public static byte or(byte a, byte b, byte c, byte d, byte e, byte f, byte g, byte h)
        => (byte)(a | b | c | d | e | f | g | h);

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static short or(short a, short b)
        => (short)(a | b);

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static ushort or(ushort a, ushort b)
        => (ushort)(a | b);

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static int or(int a, int b)
        => a | b;

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static int or(int a, int b, int c)
        => a | b | c;

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static long or(long a, long b)
        => a | b;

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static short or(short a, short b, short c)
        => (short)((int)a | (int)b | (int)c);

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    /// <param name="d">The fourth operand</param>
    [MethodImpl(Inline), Op]
    public static short or(short a, short b, short c, short d)
        => (short)((int)a | (int)b | (int)c | (int)d);

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static ushort or(ushort a, ushort b, ushort c)
        => (ushort)((uint)a | (uint)b | (uint)c);

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    /// <param name="d">The fourth operand</param>
    [MethodImpl(Inline), Op]
    public static ushort or(ushort a, ushort b, ushort c, ushort d)
        => (ushort)((uint)a | (uint)b | (uint)c | (uint)d);

    [MethodImpl(Inline), Op]
    public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e)
        => (ushort)(a | b | c | d | e);

    [MethodImpl(Inline), Op]
    public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f)
        => (ushort)(a | b | c | d | e | f);

    [MethodImpl(Inline), Op]
    public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f, ushort g)
        => (ushort)(a | b | c | d | e | f | g);

    [MethodImpl(Inline), Op]
    public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f, ushort g, ushort h)
        => (ushort)(a | b | c | d | e | f | g | h);

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    /// <param name="d">The fourth operand</param>
    [MethodImpl(Inline), Op]
    public static int or(int a, int b, int c, int d)
        => a | b | c | d;

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static uint or(uint a, uint b)
        => a | b;

    [MethodImpl(Inline), Op]
    public static uint or(uint a, uint b, uint c)
        => a | b | c;

    [MethodImpl(Inline), Op]
    public static uint or(uint a, uint b, uint c, uint d)
        => a | b | c | d;

    [MethodImpl(Inline), Op]
    public static uint or(uint a, uint b, uint c, uint d, uint e)
        => a | b | c | d | e;

    [MethodImpl(Inline), Op]
    public static uint or(uint a, uint b, uint c, uint d, uint e, uint f)
        => a | b | c | d | e | f;

    [MethodImpl(Inline), Op]
    public static uint or(uint a, uint b, uint c, uint d, uint e, uint f, uint g)
        => a | b | c | d | e | f | g;

    [MethodImpl(Inline), Op]
    public static uint or(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h)
        => a | b | c | d | e | f | g | h;        

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static long or(long a, long b, long c)
        => a | b | c;

    /// <summary>
    /// Computes the bitwise disjunction of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    /// <param name="d">The fourth operand</param>
    [MethodImpl(Inline), Op]
    public static long or(long a, long b, long c, long d)
        => a | b | c | d;

    /// <summary>
    /// Computes the bitwise or c := a | b for operands a and b
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Or]
    public static ulong or(ulong a, ulong b)
        => a | b;

    [MethodImpl(Inline), Op]
    public static ulong or(ulong a, ulong b, ulong c)
        => a | b | c;

    [MethodImpl(Inline), Op]
    public static ulong or(ulong a, ulong b, ulong c, ulong d)
        => a | b | c | d;

    [MethodImpl(Inline), Op]
    public static ulong or(ulong a, ulong b, ulong c, ulong d, ulong e)
        => a | b | c | d | e;

    [MethodImpl(Inline), Op]
    public static ulong or(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f)
        => a | b | c | d | e | f;

    [MethodImpl(Inline), Op]
    public static ulong or(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g)
        => a | b | c | d | e | f | g;

    [MethodImpl(Inline), Op]
    public static ulong or(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g, ulong h)
        => a | b | c | d | e | f | g | h;        
}
