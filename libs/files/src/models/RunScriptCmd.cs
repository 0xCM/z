//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct RunScriptCmd : ICmd<RunScriptCmd>
    {
        public const string CmdName = "run-script";

        /// <summary>
        /// The script path
        /// </summary>
        public FS.FilePath ScriptPath;
   }
}