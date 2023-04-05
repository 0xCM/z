//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public record class DirectedEdge : Edge
    {
        public DirectedEdge(Node src, params Node[] dst)
            : base(src,dst)
        {
        }

        protected override string EdgeGlyph => "->";
    }
}