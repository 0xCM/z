//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Dependency : IDependency
    {

    }

    public abstract record class Dependency<D> : Dependency, IComparable<D>
        where D : Dependency<D>
    {
        public abstract int CompareTo(D src);
    }
}