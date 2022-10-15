//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCmdFlow<S,T> : DataFlow<Tool,S,T>
    {
        public ToolCmdFlow(Tool tool, S src, T dst)
            : base(FlowId.identify(tool,src,dst), tool, src, dst)
        {

        }
    }
}