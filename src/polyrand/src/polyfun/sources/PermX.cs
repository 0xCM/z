//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Perm;

    partial class XTend
    {
        /// <summary>
        /// Shuffles the permutation in-place using a provided random source.
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        static ref readonly Perm shuffle(in Perm src, IBoundSource random)
        {
            random.Shuffle(src.Terms);
            return ref src;
        }

        /// <summary>
        /// Shuffles the permutation in-place using a provided random source.
        /// </summary>
        /// <param name="random">The random source</param>
        static NatPerm<N> Shuffle22<N>(NatPerm<N> perm, IBoundSource random)
            where N : unmanaged, ITypeNat
        {
            shuffle(perm, random);
            return perm;
        }

        public static NatPerm<N4> ToNatural(this Perm4L src)
            => api.natural(src);

        public static NatPerm<N8> ToNatural(this Perm8L src)
            => api.natural(src);

        public static NatPerm<N16> ToNatural(this Perm16L src)
            => api.natural(src);

        /// <summary>
        /// Produces a stream of random permutation of natural length N
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The length representative</param>
        /// <param name="rep">A primal type representative</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The primal symbol type</typeparam>
        public static IEnumerable<NatPerm<N>> Perms<N>(this IBoundSource random, N n = default)
            where N : unmanaged, ITypeNat
        {
            while(true)
                yield return random.Perm(n);
        }

        /// <summary>
        /// Produces a random permutation of natural length N
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The length representative</param>
        /// <param name="rep">A primal type representative</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The primal symbol type</typeparam>
        [MethodImpl(Inline)]
        public static NatPerm<N> Perm<N>(this IBoundSource random, N n = default)
            where N : unmanaged, ITypeNat
                => Shuffle22(api.natural(n), random);
    }
}