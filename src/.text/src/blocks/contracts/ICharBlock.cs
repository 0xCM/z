//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [Free]
    public interface ICharBlock : ICharSeq<char>, IStorageBlock, ICharSeq
    {
        Span<char> Data {get;}

        BitWidth ISized.BitWidth
            => (Data.Length * 2)*8;

        ReadOnlySpan<char> String {get;}

        ReadOnlySpan<byte> IByteSeq.View
            => recover<byte>(Data);

        ReadOnlySpan<char> ICellular<char>.Cells
            => Data;

        ref char First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        new ref char this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        new ref char this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        BlockKind IStorageBlock.Kind
            => BlockKind.Char16;

        Hash32 IHashed.Hash
            => hash(Data);

        string IExpr.Format()
            => new string(Data);

        bool ICharSeq.IsBlank
            => sys.blank(Data);

        bool INullity.IsEmpty
            => sys.empty(Data);

        bool INullity.IsNonEmpty
            => sys.nonempty(Data);
    }
 
    public interface ICharBlock<T> : ICharBlock, IComparable<T>, IEquatable<T>, IStorageBlock<T>, IUnmanaged<T>
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