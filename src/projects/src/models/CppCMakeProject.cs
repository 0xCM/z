//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public sealed record class CppCMakeProject : CppProject
        {
            public CppCMakeProject()
            {

            }

            public CppCMakeProject(FolderPath path)
                : base(path)
            {
               
            }
        }
    }
}