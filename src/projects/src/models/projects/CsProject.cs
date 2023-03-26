//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {    
        public sealed record class CsProject : Project<CsProject>
        {
            public CsProject()
                : base(ProjectKind.CSharp, FolderPath.Empty)
            {

            }

            public CsProject(FilePath path)
                : base(ProjectKind.CSharp, path.FolderPath)
            {

                
            }
        }

    }
}