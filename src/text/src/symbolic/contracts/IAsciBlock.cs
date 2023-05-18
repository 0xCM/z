//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAsciBlock<A> : IStorageBlock<A>, IUnmanaged<A>, IEquatable<A>
        where A : unmanaged, IAsciBlock<A>, IEquatable<A>
    {
        ref byte First {get;}

        BlockKind IStorageBlock.Kind
            => BlockKind.Char8;
    }
}