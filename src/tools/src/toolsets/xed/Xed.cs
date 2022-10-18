//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    public sealed class XedTool : Tool<XedTool>
    {
        public XedTool()
            : base(N.xed)
        {

        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }   
}