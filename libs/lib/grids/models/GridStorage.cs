//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies the memory storage required for a specified grid
    /// </summary>
    public readonly struct GridStorage : IEquatable<GridStorage>
    {
        /// <summary>
        /// The the total number of segment-aligned bits allocated for storage
        /// </summary>
        public readonly BitWidth BitCount;

        /// <summary>
        /// The number of bits in each segment
        /// </summary>
        public readonly uint SegWidth;

        /// <summary>
        /// The the total number of segments allocated for storage
        /// </summary>
        public readonly uint SegCount;

        [MethodImpl(Inline)]
        public GridStorage(BitWidth bits, uint segwdith)
        {
            BitCount = bits;
            SegWidth = segwdith;
            SegCount = bits/segwdith;
        }

        /// <summary>
        /// The the total number of segment-aligned bytes allocated for storage
        /// </summary>
        public ByteSize AlignedBytes
        {
            [MethodImpl(Inline)]
            get => BitCount.Bytes;
        }

        /// <summary>
        /// The count of remaining unaligned bits
        /// </summary>
        public BitWidth Remainder
        {
            [MethodImpl(Inline)]
            get => SegCount % SegWidth;
        }

        [MethodImpl(Inline)]
        public bool Equals(GridStorage src)
            => src.BitCount == BitCount && src.SegCount == SegCount;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => HashCode.Combine(BitCount,SegCount);

        public override bool Equals(object src)
            => src is GridStorage x && Equals(x);

        public string Format()
            => EmptyString;
    }
}