//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/clean")]
        Outcome CleanProject(CmdArgs args)
        {
            var project = Project();
            Status(string.Format("Cleared {0}", Projects.CleanOutDir(project)));
            return true;
        }
    }
}