//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Creates an 8-bit vector by concatenating a pair of 4-bit vectors
        /// </summary>
        /// <param name="a">The lower bits of the new vector</param>
        /// <param name="b">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 join(BitVector4 a, BitVector4 b)
            => create(n8,b.Data << 4 | a.Data);

        /// <summary>
        /// Creates a 16-bit vector by concatenating 4 4-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that from the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 join(BitVector4 x0, BitVector4 x1, BitVector4 x2, BitVector4 x3)
            => join(join(x0,x1), join(x2,x3));

        /// <summary>
        /// Creates an 16-bit vector by concatenating a pair of 8-bit vectors
        /// </summary>
        /// <param name="lo">The lower bits of the new vector</param>
        /// <param name="hi">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 join(BitVector8 lo, BitVector8 hi)
            => create(n16, lo.Data, hi.Data);

        /// <summary>
        /// Creates a 32-bit vector by concatenating a pair of 16-bit vectors
        /// </summary>
        /// <param name="a">The lower bits of the new vector</param>
        /// <param name="b">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 join(BitVector16 a, BitVector16 b)
            => create(n32, a.Data, b.Data);

        /// <summary>
        /// Creates a 32-bit vector by concatenating 4 8-bit vectors
        /// </summary>
        /// <param name="a">The first segment that forms the least significant bits of the new vector</param>
        /// <param name="b">The second segment</param>
        /// <param name="c">The third segment</param>
        /// <param name="d">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 join(BitVector8 a, BitVector8 b, BitVector8 c, BitVector8 d)
            => create(n32, a.Data, b.Data, c.Data, d.Data);

        /// <summary>
        /// Creates a 64-bit vector by concatenating 8 8-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that forms the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The fourth segment</param>
        /// <param name="x4">The fifth segment</param>
        /// <param name="x5">The sixth segment</param>
        /// <param name="x6">The pentultimate segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 join(BitVector8 x0, BitVector8 x1, BitVector8 x2,  BitVector8 x3,
            BitVector8 x4, BitVector8 x5, BitVector8 x6,  BitVector8 x7)
                => join(join(x0,x1,x2,x3), join(x4,x5,x6,x7));

        /// <summary>
        /// Creates a 64-bit vector by concatenating 4 16-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that forms the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 join(BitVector16 x0, BitVector16 x1, BitVector16 x2, BitVector16 x3)
            => create(n64, x0.Data, x1.Data, x2.Data, x3.Data);

        /// <summary>
        /// Creates a 64-bit vector by concatenating a pair of 32-bit vectors
        /// </summary>
        /// <param name="a">The lower bits of the new vector</param>
        /// <param name="b">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 join(BitVector32 a, BitVector32 b)
            => create(n64, a.Data, b.Data);
    }
}