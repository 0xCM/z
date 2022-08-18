//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenSet
    {

    }

    public interface ITokenSet<K> : ITokenSet
        where K : unmanaged
    {

    }

    public interface ITokenSet<S,K> : ITokenSet<K>
        where S : ITokenSet<S,K>, new()
        where K : unmanaged
    {

    }
}