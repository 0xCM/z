//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 dec(BitVector4 x)
        {
            if(x.State > 0)
                return x.Data--;
            else
                return  0xF;
        }

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 dec(BitVector8 x)
            => gmath.dec(x.State);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 dec(BitVector16 x)
            => gmath.dec(x.State);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 dec(BitVector32 x)
            => gmath.dec(x.State);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 dec(BitVector64 x)
            => gmath.dec(x.State);

    }
}