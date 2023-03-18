//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectFiles
    {
        public class WorkspaceFolder
        {
            public @string Name;

            public FolderPath Path;

            public WorkspaceFolder(@string name, FolderPath path)            
            {
                Name = name;
                Path = path;
            }

            public WorkspaceFolder(FolderPath path)            
            {
                Name = @string.Empty;
                Path = path;
            }

            public static implicit operator WorkspaceFolder(FolderPath path)
                => new WorkspaceFolder(path);            
        }
    }
}