//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeString<S,K> : IString<S,K>
        where K : unmanaged, IEquatable<K>, IComparable<K>
        where S : unmanaged, INativeString<S,K>
    {

    }

    [Free]
    public interface INativeString<S,K,B> : INativeString<S,K>
        where K : unmanaged, IEquatable<K>, IComparable<K>
        where B : unmanaged, IStorageBlock<B>
        where S : unmanaged, INativeString<S,K,B>
    {

    }
}