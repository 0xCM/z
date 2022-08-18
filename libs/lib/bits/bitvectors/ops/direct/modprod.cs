//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op]
        public static bit modprod(BitVector4 x, BitVector4 y)
        {
            var result = 0;
            var w = x.Width;
            for(var i=z8; i<w; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return math.odd(result);
        }

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="lhs">The first vector</param>
        /// <param name="rhs">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op]
        public static bit modprod(BitVector8 x, BitVector8 y)
        {
            var result = 0;
            var w = x.Width;
            for(var i=z8; i<w; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return math.odd(result);
        }

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op]
        public static bit modprod(BitVector16 x, BitVector16 y)
        {
            var result = 0;
            var w = x.Width;
            for(var i=z8; i<w; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return math.odd(result);
        }

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op]
        public static bit modprod(BitVector32 x, BitVector32 y)
        {
            var result = 0;
            var w = x.Width;
            for(var i=z8; i<w; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return math.odd(result);
        }

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op]
        public static bit modprod(BitVector64 x, BitVector64 y)
        {
            var result = 0;
            var w = x.Width;
            for(var i=z8; i<w; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return math.odd(result);
        }
    }
}