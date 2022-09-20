//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class RunScript : CmdReactor<RunScript,RunScriptCmd>
    {
        protected override CmdResult Run(RunScriptCmd cmd)
        {
            ProcExec.start(ProcExec.cmd(cmd.ScriptPath)).Wait();
            return CmdResults.ok(cmd);
        }
    }
}