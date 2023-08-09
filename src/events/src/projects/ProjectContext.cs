//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectContext
    {
        public readonly IProject Project;

        public ProjectContext(IProject project)
        {
            Project = project;
        }

    }
}