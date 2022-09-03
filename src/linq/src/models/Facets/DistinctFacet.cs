//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FacetsDynamic
    {
        public sealed class DistinctFacet : SelectionFacet<DistinctFacet,bool>
        {
            public DistinctFacet(bool Enabled = true)
                : base("Distinct", Enabled)
            {

            }
        }
    }
}