//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class RunToolScript : CmdReactor<RunToolScript,RunScriptCmd>
    {
        protected override CmdResult Run(RunScriptCmd cmd)
        {
            ProcessControl.start(Channel, ProcessControl.cmd(cmd.ScriptPath)).Wait();
            return CmdResults.ok(cmd);
        }
    }
}