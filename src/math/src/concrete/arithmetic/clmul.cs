//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Pclmulqdq = System.Runtime.Intrinsics.X86.Pclmulqdq;

partial class math
{
    /// <summary>
    /// Computes the caryless 16-bit product of two 8-bit operands
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), ClMul]
    public static ushort clmul(byte a, byte b)
        => (ushort)clmul((uint)a, (uint)b);

    /// <summary>
    /// Returns the caryless 32 bit product of two 16-bit operands
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), ClMul]
    public static uint clmul(ushort a, ushort b)
        => (uint)clmul((uint)a, (uint)b);

    /// <summary>
    /// Returns the caryless 64 bit product from two 32-bit operands
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), ClMul]
    public static ulong clmul(uint a, uint b)
        => clmul((ulong)a, (ulong)b).Left;

    /// <summary>
    /// Computes the caryless 128-bit product of two 64-bit operands
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), ClMul]
    public static ConstPair<ulong> clmul(ulong a, ulong b)
    {
        var m0 = Vector128.CreateScalarUnsafe(a);
        var m1 = Vector128.CreateScalarUnsafe(b);
        var result = Pclmulqdq.CarrylessMultiply(m0,m1,0x00);
        return (result.GetElement(0), result.GetElement(1));
    }

    /// <summary>
    /// Computes the carryless product of the operands reduced by a specified polynomial
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="poly">The reducing polynomial</param>
    [MethodImpl(Inline), ClMul]
    public static byte clmulr(N8 r, byte a, byte b, ushort poly)
    {
        var prod = clmul(a,b);
        prod ^= (ushort)clmul((ushort)(prod >> 8), poly);
        prod ^= (ushort)clmul((ushort)(prod >> 8), poly);
        return (byte)prod;
    }

    [MethodImpl(Inline), ClMul]
    public static ulong clmulr(N8 r, ulong a, ulong b, ulong poly)
    {
        var product = clmul64(a,b);
        product ^= clmul64(product >> 8, poly);
        product ^= clmul64(product >> 8, poly);
        return product;
    }

    /// <summary>
    /// Computes the carryless product of the operands reduced by a specified polynomial
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="poly">The reducing polynomial</param>
    [MethodImpl(Inline), ClMul]
    public static ushort clmulr(N16 r, ushort a, ushort b, uint poly)
    {
        var prod = clmul(a,b);
        prod ^= (uint)clmul(prod >> 16, poly);
        prod ^= (uint)clmul(prod >> 16, poly);
        return (ushort)prod;
    }

    /// <summary>
    /// Computes the carryless product of the operands reduced by a specified polynomial
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="poly">The reducing polynomial</param>
    [MethodImpl(Inline), ClMul]
    public static uint clmulr(N32 r, uint a, uint b, ulong poly)
    {
        var prod = clmul(a,b);
        prod ^= clmul(prod >> 32, poly).Left;
        prod ^= clmul(prod >> 32, poly).Left;
        return (uint)prod;
    }

    [MethodImpl(Inline), ClMul]
    public static ulong clmul64(ulong x, ulong y)
    {
        var u = Vector128.CreateScalarUnsafe(x);
        var v = Vector128.CreateScalarUnsafe(y);
        var z = Pclmulqdq.CarrylessMultiply(u, v, 0);
        return z.GetElement(0);
    }
}