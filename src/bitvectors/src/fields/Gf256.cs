//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public static class Gf256
{
    public const int MemberCount = 256;

    static readonly ushort Redux = GfPoly.Lookup<N8,ushort>().Scalar;

    /// <summary>
    /// Computes the GF(256) product reduced by the canonical polynomial
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline)]
    public static byte clmul(byte a, byte b)
        => math.clmulr(n8, a, b, Redux);

    /// <summary>
    /// Fills caller-allocated memory with a GF(256) multiplication table
    /// </summary>
    /// <param name="min">The minimum operand value</param>
    /// <param name="max">The maximum operand value</param>
    public static void products(byte min, byte max, ref byte dst)
    {
        var width = max - min + 1;
        var cells = width*width;
        var index = 0;
        for(byte i=min; i<= max; i++)
        for(byte j=min; j<= max; j++)
            Unsafe.Add(ref dst,index++) = clmul(i,j);
    }

    /// <summary>
    /// The reference (slow) implementation of GF(256) multiplication reduced
    /// via the canonical polynomial
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    public static byte mul_ref(byte a, byte b)
    {
        ulong r = Redux;
        var p = 0ul;
        ulong x = a;
        ulong y = b;
        for(var i=0; i<8; i++)
        {
            if((x & (1ul << i)) != 0)
                p^= (y << i);
        }

        for(var i=14; i>=8; i--)
        {
            if((p & (1ul << i)) != 0)
                p^= (r <<(i-8));
        }
        return (byte)p;
    }
}
