//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class XedTool : Tool<XedTool>
    {
        public XedTool()
            : base("xed")
        {

        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }   
}