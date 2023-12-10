//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitGrid
{
    /// <summary>
    /// Enumerates the valid grid dimensions where the total bit width is a power of 2
    /// </summary>
    /// <typeparam name="W">The grid dimension type</typeparam>
    public static IEnumerable<Pair<ulong>> p2dimensions<W>()
        where W : unmanaged,INatPow2<W>
            => p2dimensions(TypeNats.nat32u<W>());

    /// <summary>
    /// Enumerates the valid grid dimensions where the total bit width is a power of 2
    /// </summary>
    /// <param name="w">A power of 2 that specifies the bit width of the grid</param>
    public static IEnumerable<Pair<ulong>> p2dimensions(ulong w)
    {
        ulong m = 1;
        ulong n = w;
        var failsafe = 65;

        if(math.ispow2(w))
        {
            while(--failsafe >= 0)
            {
                yield return Tuples.pair(m,n);

                if(m == n)
                    break;

                yield return Tuples.pair(n,m);

                m <<= 1;

                if(m == n)
                    break;

                n >>= 1;
            }
        }
    }
}
