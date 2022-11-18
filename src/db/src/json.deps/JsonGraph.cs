//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class JsonGraph : Lineage<JsonGraph,string>
    {
        public JsonGraph()
            : base(EmptyString, sys.empty<string>())
        {

        }

        public JsonGraph(string node, string[] src)
        : base(node,src)
        {

        }
    }
}