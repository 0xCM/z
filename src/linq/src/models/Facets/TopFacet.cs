//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FacetsDynamic
    {
        public sealed class TopFacet : SelectionFacet<TopFacet,int>
        {
            public TopFacet(int Count)
                : base("Top", Count)
            {

            }
        }
    }
}