//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{

    partial class ClrQuery
    {
        public static TypeAttribution<A>[] Attributions<A>(this Type[] src)
            where A : Attribute
                => src.Where(t => t.Tagged<A>()).Select(x => new TypeAttribution<A>(x,x.Tag<A>().Require()));
    }
}
