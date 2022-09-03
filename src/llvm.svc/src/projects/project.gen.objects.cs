//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/gen/objects")]
        void GenProjectObjectsx()
            => ProjectSvc.GenProjectObjects(Project());
    }
}