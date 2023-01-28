//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectFile : ProjectMember
    {
        public FilePath Location {get;}

        public ProjectFile(IProject project, FilePath location)
            : base(project, location.Format() )
        {

        }
    }    
}