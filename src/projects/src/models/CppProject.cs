//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {    
        public sealed record class CppProject : DevProject<CppProject>
        {
            public CppProject()
                : base(ProjectKind.Cpp, FolderPath.Empty)
            {

            }

            public CppProject(FolderPath path)
                : base(ProjectKind.Cpp, path)
            {

                
            }
        }
    }
}