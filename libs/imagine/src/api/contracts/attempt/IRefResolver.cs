//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IRefResolver<K,V>
        where K : unmanaged
    {
        ref V Resolve(K key);
    }

    [Free]
    public interface IRefResolver<V> : IRefResolver<uint,V>
    {

    }

}