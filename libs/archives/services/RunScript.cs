//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ListFiles : CmdReactor<ListFiles,ListFilesCmd,CmdResult>
    {
        protected override CmdResult Run(ListFilesCmd cmd)
            => default;
    }

    sealed class RunScript : CmdReactor<RunScript,RunScriptCmd>
    {
        protected override CmdResult Run(RunScriptCmd cmd)
        {
            var result = CmdLauncher.start(CmdScripts.cmd(cmd.ScriptPath)).Wait();
            return CmdResults.ok(cmd);
        }
    }
}