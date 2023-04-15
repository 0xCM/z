//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {    
        public sealed record class CIlProject : DevProject<CIlProject>
        {
            public CIlProject()
                : base(ProjectKind.CSharp, FolderPath.Empty)
            {

            }

            public CIlProject(FolderPath root)
                : base(ProjectKind.Cil, root)
            {

                
            }
        }
    }
}