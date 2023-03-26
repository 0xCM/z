//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {    
        public abstract record class CppProject : Project<CIlProject>
        {
            public CppProject()
                : base(ProjectKind.Cpp, FolderPath.Empty)
            {

            }

            public CppProject(FolderPath path)
                : base(ProjectKind.Cil, path)
            {

                
            }
        }
    }
}