//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class BitMatrix4x
    {
        [MethodImpl(Inline)]
        public static BitMatrix4 Replicate(this BitMatrix4 src)
            => (ushort)src;

        /// <summary>
        /// Converts the matrix to a bitvector
        /// </summary>
        [MethodImpl(Inline)]
        public static BitVector16 ToBitVector(this BitMatrix4 A)
            => (ushort)A;

        [MethodImpl(Inline)]
        public static string Format(this BitMatrix4 src)
            => sys.bytes(src).FormatGridBits(src.Order);

        /// <summary>
        /// Transposes a copy of the source matrix
        /// </summary>
        [MethodImpl(Inline)]
        public static BitMatrix4 Transpose(this BitMatrix4 A)
            => BitMatrix.transpose(A);
    }
}