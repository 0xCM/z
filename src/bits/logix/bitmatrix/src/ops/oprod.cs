//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMatrix
    {
        /// <summary>
        /// Computes the outer product of two bitvectors and returns the allocated result
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Outer_product</remarks>
        [MethodImpl(Inline)]
        public static BitMatrix<uint> oprod(BitVector32 x, BitVector32 y)
            => oprod(x.ToGeneric(), y.ToGeneric());

        /// <summary>
        /// Computes the outer product of two bitvectors and stores the result in a caller-supplied target
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Outer_product</remarks>
        [MethodImpl(Inline)]
        public static ref BitMatrix<T> oprod<T>(ScalarBits<T> x, ScalarBits<T> y, ref BitMatrix<T> dst)
            where T : unmanaged
        {
            int order = (int)width<T>();
            var rhs = (T)y;
            ref var href = ref dst.Head;
            for(byte i=0; i<order; i++)
                seek(href, i) = x[i] ? rhs : default;
            return ref dst;
        }

        /// <summary>
        /// Computes the outer product of two bitvectors and returns the allocated result
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Outer_product</remarks>
        [MethodImpl(Inline)]
        public static BitMatrix<T> oprod<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var dst = BitMatrix.alloc<T>();
            return oprod(x,y, ref dst);
        }
    }
}