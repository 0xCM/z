//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectFolder : ProjectMember
    {
        public FolderPath Location {get;}

        public ProjectFolder(IProject project, FolderPath location)
            : base(project, location.Format())
        {

        }
    }
}