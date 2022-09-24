//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        public static TaggedType<A>[] TaggedTypes<A>(this Assembly[] a)
            where A : Attribute
                => a.Types().Where(t => t.Tagged<A>()).Select(t => new TaggedType<A>(t, t.Tag<A>().Require()));
    }
}