//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {    
        public record class BinaryProject : Project<BinaryProject>
        {
            public readonly FileIndex Files;   

            public BinaryProject()
                : base(ProjectKind.Binary)
            {
                Files = new();
            }

            public BinaryProject(FolderPath root, FileIndex files)
                : base(ProjectKind.Binary, root)
            {
                Files = files;
            }
        }
    }    
}