//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolProcess : IToolProcess
    {
        public ITool Tool {get;}

        protected ToolProcess(ITool tool)
        {
            Tool = tool;
        }
    }    
}