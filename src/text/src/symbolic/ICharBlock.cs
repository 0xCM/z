//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface ICharBlock<T> : ICharBlock, IComparable<T>, IEquatable<T>, IStorageBlock<T>
        where T : unmanaged, ICharBlock<T>
    {
        ByteSize ISized.ByteCount
            => size<T>();

        BitWidth ISized.BitWidth
            => width<T>();

        int IByteSeq.Capacity
            => Length*2;

        Span<byte> IStorageBlock.Bytes
            => recover<byte>(Data);

        int IComparable<T>.CompareTo(T src)
            => Cells.SequenceCompareTo(src.Cells);

        bool IEquatable<T>.Equals(T src)
            => Cells.SequenceEqual(src.Cells);

        bool ICharSeq.IsNull
            => Data.SequenceEqual(default(T).Data);
    }
}