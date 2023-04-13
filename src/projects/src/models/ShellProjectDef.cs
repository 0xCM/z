//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ShellProjectDef
    {
        public readonly FolderPath Root;

        public readonly @string ProjectName;

        public readonly @string ShellName;

        public ShellProjectDef(FolderPath root, @string? project = null, @string? shell = null)
        {
            Root = root;
            ProjectName = project ?? root.FolderName.Format();
            ShellName = shell ?? root.FolderName.Format();
        }
        
        public string SlnName 
            => Root.FolderName.Format();

        public string FrameworkMoniker
            => "net7.0";
            
        public FolderPath SlnCmd 
            => Root + FS.folder("cmd");

        public FolderPath SlnProps
            => Root + FS.folder("props");

        public FolderPath SlnBuild
            => Root + FS.folder("build");

        public FolderPath SlnSrc
            => Root + FS.folder("src");

        public FilePath ProjectFilePath 
            => SlnSrc + FS.file(ProjectName, FileKind.CsProj);

        public FilePath SlnFilePath
            => Root + FS.file(Root.FolderName.Format(), FileKind.Sln);

        public FilePath ConfigFilePath
            => Root + FS.file("config", FileKind.Cmd);
    }
}