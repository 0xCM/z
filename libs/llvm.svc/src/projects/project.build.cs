//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/build")]
        Outcome BuildProject(CmdArgs args)
        {
            var project = Project();
            if(BuildCmdNames.TryGetValue(project.Name, out var name))
                RunCmd(name);
            else
                Warn(string.Format("No build job found for {0}", project.Name));

            return true;
        }
    }
}