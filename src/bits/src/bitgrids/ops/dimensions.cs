//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static grids;

    partial class BitGrid
    {
        /// <summary>
        /// Enumerates the valid dimensions for a 16-bit fixed bitgrid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        public static IEnumerable<Dim2<byte>> dims(N8 w)
        {
            yield return dim(n1,n8);
            yield return dim(n8,n1);
            yield return dim(n2,n4);
            yield return dim(n4,n2);
        }

        /// <summary>
        /// Enumerates the valid dimensions for a 16-bit fixed bitgrid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        public static IEnumerable<Dim2<byte>> dims(N16 w)
        {
            yield return dim(n1, n16);
            yield return dim(n16 ,n1);
            yield return dim(n2, n8);
            yield return dim(n8, n2);
            yield return dim(n4, n4);
        }

        /// <summary>
        /// Enumerates the valid dimensions for a 32-bit fixed bitgrid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        public static IEnumerable<Dim2<byte>> dims(N32 w)
        {
            yield return dim(n1, n32);
            yield return dim(n32, n1);
            yield return dim(n2, n16);
            yield return dim(n16, n2);
            yield return dim(n8, n4);
            yield return dim(n4, n8);
        }

        /// <summary>
        /// Enumerates the valid dimensions for a 64-bit fixed bitgrid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        public static IEnumerable<Dim2<byte>> dims(N64 w)
        {
            yield return dim(n1,n64);
            yield return dim(n64,n1);
            yield return dim(n2,n32);
            yield return dim(n32,n2);
            yield return dim(n16,n4);
            yield return dim(n4,n16);
            yield return dim(n8,n8);
        }

        /// <summary>
        /// Enumerates the valid dimensions for a 128-bit fixed bitgrid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        public static IEnumerable<Dim2<byte>> dims(N128 w)
        {
            yield return dim(n1,n128);
            yield return dim(n128,n1);
            yield return dim(n2,n64);
            yield return dim(n64,n2);
            yield return dim(n32,n4);
            yield return dim(n4,n32);
            yield return dim(n8,n16);
            yield return dim(n16,n8);
        }

        /// <summary>
        /// Enumerates the valid dimensions for a 256-bit fixed bitgrid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        public static IEnumerable<Dim2<ushort>> dims(N256 w)
        {
            yield return dim(n1,n256);
            yield return dim(n256,n1);
            yield return dim(n2,n128);
            yield return dim(n128,n2);
            yield return dim(n64,n4);
            yield return dim(n4,n64);
            yield return dim(n8,n32);
            yield return dim(n32,n8);
            yield return dim(n16,n16);
        }

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
}