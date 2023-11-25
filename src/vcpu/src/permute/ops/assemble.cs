//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Permute
{
    // <summary>
    /// Constructs a permutation of length four from four ordered symbols
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Perm4L assemble(Perm4L x0, Perm4L x1, Perm4L x2, Perm4L x3)
        => (Perm4L)assemble4((uint)x0, (uint)x1, (uint)x2, (uint)x3);

    /// <summary>
    /// Constructs a permutation of length 8 from 8 ordered symbols
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Perm8L assemble(
        Perm8L x0, Perm8L x1, Perm8L x2, Perm8L x3,
        Perm8L x4, Perm8L x5, Perm8L x6, Perm8L x7)
    {
        var dst = (uint)x0       | (uint)x1 << 3  | (uint)x2 << 6  | (uint)x3 << 9
                | (uint)x4 << 12 | (uint)x5 << 15 | (uint)x6 << 18 | (uint)x7 << 21;
        return (Perm8L)dst;
    }

    /// <summary>
    /// Constructs a permutation of length 16 from 16 ordered symbols
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Perm16L assemble(
        Perm16L x0, Perm16L x1, Perm16L x2, Perm16L x3,
        Perm16L x4, Perm16L x5, Perm16L x6, Perm16L x7,
        Perm16L x8, Perm16L x9, Perm16L xA, Perm16L xB,
        Perm16L xC, Perm16L xD, Perm16L xE, Perm16L xF)
            => (Perm16L)assemble16(
                    (ulong)x0,(ulong)x1,(ulong)x2,(ulong)x3,
                    (ulong)x4,(ulong)x5,(ulong)x6,(ulong)x7,
                    (ulong)x8,(ulong)x9,(ulong)xA,(ulong)xB,
                    (ulong)xC,(ulong)xD,(ulong)xE,(ulong)xF
                    );

    [MethodImpl(Inline)]
    static uint assemble4(uint x0, uint x1, uint x2, uint x3)
        => x0 | x1 << 2 | x2 << 4 | x3 << 6;

    [MethodImpl(Inline)]
    static ulong assemble16(
        ulong x0, ulong x1, ulong x2, ulong x3,
        ulong x4, ulong x5, ulong x6, ulong x7,
        ulong x8, ulong x9, ulong xA, ulong xB,
        ulong xC, ulong xD, ulong xE, ulong xF)
            => x0 | x1 << 4  | x2 << 8  | x3 << 12
                | x4 << 16 | x5 << 20 | x6 << 24 | x7 << 28
                | x8 << 32 | x9 << 36 | xA << 40 | xB << 44
                | xC << 48 | xD << 52 | xE << 56 | xF << 60;
}
