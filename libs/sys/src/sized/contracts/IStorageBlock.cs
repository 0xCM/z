//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IStorageBlock : IHashed, INullity, ISized
    {
        Span<byte> Bytes {get;}

        BlockKind Kind
            => BlockKind.Bytes;

        bool INullity.IsEmpty
            => Bytes.Length == 0;

        bool INullity.IsNonEmpty
            => Bytes.Length != 0;

        Hash32 IHashed.Hash
            => hash(Bytes);
    }

    public interface IStorageBlock<T> : IStorageBlock
        where T : unmanaged, IStorageBlock<T>
    {
        ByteSize ISized.ByteCount
            => size<T>();

        BitWidth ISized.BitWidth
            => width<T>();

        Span<byte> IStorageBlock.Bytes
            => bytes((T)this);
    }
}