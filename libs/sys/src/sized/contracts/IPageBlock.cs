//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPageBlock : IStorageBlock
    {
        BlockKind IStorageBlock.Kind
            => BlockKind.Page;
    }

    public interface IPageBlock<T> : IPageBlock, IStorageBlock<T>
        where T : unmanaged, IPageBlock<T>
    {
        uint PageCount
            => ByteCount/PageSize;
    }
}