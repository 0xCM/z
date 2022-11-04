//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NameResolvers : NameResolver<NameResolvers, NameResolver>
    {

    }

    public class NameResolvers<T>  : NameResolver<NameResolvers<T>, T>
        where T : NameResolver<T>, new()
    {

    }
}