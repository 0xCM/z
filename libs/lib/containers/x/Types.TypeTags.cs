//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class XTend
    {
        public static Pairings<Type,A> TypeTags<A>(this Type[] src)
            where A : Attribute
                => src.Tagged<A>().Select(t => Tuples.paired(t,t.Tag<A>().Require()));
    }
}