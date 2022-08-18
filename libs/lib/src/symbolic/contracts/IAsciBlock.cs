//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAsciBlock<A> : IStorageBlock<A>
        where A : unmanaged, IAsciBlock<A>
    {
        ref byte First {get;}

        BlockKind IStorageBlock.Kind
            => BlockKind.Char8;
    }
}