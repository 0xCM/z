//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct FlowCommands : IFlowCommands
    {
        public static IFlowCommands Service => new FlowCommands();
    }
}