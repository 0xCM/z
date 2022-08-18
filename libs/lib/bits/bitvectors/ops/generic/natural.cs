//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Defines a bitvector of natural width
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="a">The scalar source data</param>
        /// <typeparam name="N">The width type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> natural<N,T>(N n, T a)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new ScalarBits<N,T>(a);

        /// <summary>
        /// Defines a bitvector of natural width
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="a">The scalar source data</param>
        /// <typeparam name="N">The width type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> natural<N,T>(T a)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new ScalarBits<N,T>(a);

        /// <summary>
        /// Creates a vector from a bitstring
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> natural<N,T>(BitString src, N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => packseq(src.Slice(0, Typed.nat32i(n)).BitSeq, out T _);
    }
}