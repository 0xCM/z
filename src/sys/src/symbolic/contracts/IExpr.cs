//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IExpr<K> : IExpr, IKinded<K>
        where K : unmanaged
    {
        ulong IKinded.Kind
            => sys.bw64((this as IKinded<K>).Kind);
    }
}