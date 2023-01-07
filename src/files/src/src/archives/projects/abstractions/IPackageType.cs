//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPackageType
    {
        @string Name {get;}
    }

    public interface IPackageType<K> : IPackageType
        where K : IPackageType<K>, new()
    {

    }

}