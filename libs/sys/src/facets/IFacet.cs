//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFacet<K,V> : IKeyed<K>
        where K : IEquatable<K>, IComparable<K>
    {
        V Value {get;}
    }
}