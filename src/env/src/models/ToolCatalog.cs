//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCatalog : ReadOnlySeq<ToolCatalog,LocatedTool>
    {
            
        public ToolCatalog()
        {
        }

        public ToolCatalog(LocatedTool[] src)
            : base(src)
        {
        }



        public static implicit operator ToolCatalog(LocatedTool[] src)
            => new ToolCatalog(src);
    }
}