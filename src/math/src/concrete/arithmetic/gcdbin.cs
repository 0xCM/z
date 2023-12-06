//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Binary gcd, Wikipedia version
    /// </summary>
    /// <param name="u"></param>
    /// <param name="v"></param>
    /// <remarks>See https://en.wikipedia.org/wiki/Binary_GCD_algorithm</remarks>
    [Op]
    public static uint gcdbin(uint u, uint v)
    {
        // simple cases (termination)
        if (u == v)
            return u;

        if (u == 0)
            return v;

        if (v == 0)
            return u;

        // look for factors of 2
        if ( (~u & 1) != 0) // u is even
        {
            if ( (v & 1) != 0) // v is odd
                return gcdbin(u >> 1, v);
            else // both u and v are even
                return gcdbin(u >> 1, v >> 1) << 1;
        }

        if ( (~v & 1) != 0) // u is odd, v is even
            return gcdbin(u, v >> 1);

        // reduce larger argument
        if (u > v)
            return gcdbin((u - v) >> 1, v);

        return gcdbin((v - u) >> 1, u);
    }


    /// <summary>
    /// Binary gcd, Wikipedia version
    /// </summary>
    /// <param name="u"></param>
    /// <param name="v"></param>
    /// <remarks>See https://en.wikipedia.org/wiki/Binary_GCD_algorithm</remarks>
    [Op]
    public static ulong gcdbin(ulong u, ulong v)
    {
        // simple cases (termination)
        if (u == v)
            return u;

        if (u == 0)
            return v;

        if (v == 0)
            return u;

        // look for factors of 2
        if ( (~u & 1) != 0) // u is even
        {
            if ( (v & 1) != 0) // v is odd
                return gcdbin(u >> 1, v);
            else // both u and v are even
                return gcdbin(u >> 1, v >> 1) << 1;
        }

        if ( (~v & 1) != 0) // u is odd, v is even
            return gcdbin(u, v >> 1);

        // reduce larger argument
        if (u > v)
            return gcdbin((u - v) >> 1, v);

        return gcdbin((v - u) >> 1, u);
    }

    [MethodImpl(Inline)]
    public static byte gcdbin(byte u, byte v)
        => (byte)gcdbin((uint)u, (uint)v);

    [MethodImpl(Inline)]
    public static ushort gcdbin(ushort u, ushort v)
        => (ushort)gcdbin((uint)u, (uint)v);
}
