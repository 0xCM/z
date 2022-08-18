//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        [MethodImpl(Inline), Inc]
        public static BitVector4 inc(BitVector4 x)
        {
            if(x.State < 0xF)
                return x.Data++;
            else
                return BitVector4.Zero;
        }

        /// <summary>
        /// Increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static BitVector8 inc(BitVector8 x)
            => math.inc(x.State);

        /// <summary>
        /// Increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static BitVector16 inc(BitVector16 x)
            => math.inc(x.State);

        /// <summary>
        /// Increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static BitVector32 inc(BitVector32 x)
            => math.inc(x.State);

        /// <summary>
        /// Increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static BitVector64 inc(BitVector64 x)
            => math.inc(x.State);
    }
}