//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectFiles
    {
        public class WorkspaceFile
        {
            public static FilePath path(FolderPath root) => root + FS.file(root.FolderName.Format(), FS.ext("code-workspace"));

            public readonly FilePath Path;

            public ReadOnlySeq<WorkspaceFolder> Folders {get;}

            public WorkspaceFile(FilePath path, params WorkspaceFolder[] folders)
            {
                Path = path;
                Folders = folders;
            }

            public static WorkspaceFile Empty => new WorkspaceFile(FilePath.Empty, sys.empty<WorkspaceFolder>());
        }
    }
}