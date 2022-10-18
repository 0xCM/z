//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class WfCmdLine : WfAction<WfCmdLine>
    {
        public WfCmdLine()
        {
            Spec = CmdLine.Empty;
        }

        public WfCmdLine(CmdLine spec)
        {
            Spec = spec;
        }

        public CmdLine Spec {get;}
    }
}