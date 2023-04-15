//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CodeWorkspace : ProjectFile<CodeWorkspace>
    {
        public static FilePath path(FolderPath root) 
            => root + FS.file(root.FolderName.Format(), FS.ext("code-workspace"));

        public readonly FilePath Path;

        public ReadOnlySeq<WorkspaceFolder> Folders {get;}

        public CodeWorkspace()
        {
            Path = FilePath.Empty;
            Folders = sys.empty<WorkspaceFolder>();
        }

        public CodeWorkspace(FilePath path, params WorkspaceFolder[] folders)
        {
            Path = path;
            Folders = folders;
        }

        public static CodeWorkspace Empty => new CodeWorkspace(FilePath.Empty, sys.empty<WorkspaceFolder>());
    }
}