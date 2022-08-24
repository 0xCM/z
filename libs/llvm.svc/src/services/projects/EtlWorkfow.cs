//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectSvc
    {
        public void Etl(IProjectWorkspace project)
        {
            var context = Projects.context(project);
            AsmObjects.RunEtl(context);
            XedDisasm.Collect(context);
        }
    }
}