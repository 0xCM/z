//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class PackageType<K> : IPackageType<K>
        where K : PackageType<K>, new()
    {
        public @string Name {get;}
    }

}