//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {    
        public record class BinaryProject : DevProject<BinaryProject>
        {
            public BinaryProject()
                : base(ProjectKind.Binary)
            {
            }

            public BinaryProject(FolderPath root)
                : base(ProjectKind.Binary, root)
            {
            }
        }
    }    
}