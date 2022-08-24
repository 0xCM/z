//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Facets : Seq<Facets,Facet>
    {
        public Facets()
        {


        }

        [MethodImpl(Inline)]
        public Facets(Facet[] src)
        {
            Data = src;

        }

        [MethodImpl(Inline)]
        public static implicit operator Facets(Facet[] src)
            => new Facets(src);

        [MethodImpl(Inline)]
        public static implicit operator Facet[](Facets src)
            => src.Data.Storage;
    }
}