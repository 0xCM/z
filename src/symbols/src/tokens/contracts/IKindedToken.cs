//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IKindedToken<K,V> : IKinded<K>, IValued<V>, INullity
    where K : unmanaged
    where V : unmanaged
{
    
}
