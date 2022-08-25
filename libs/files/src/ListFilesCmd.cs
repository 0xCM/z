//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct ListFilesCmd : ICmd<ListFilesCmd>
    {
        public const string CmdName = "list-files";

        [Render(16)]
        public string ListName;

        [Render(48)]
        public FolderPath SourceDir;

        [Render(16)]
        public Index<FileExt> Extensions;

        [Render(16)]
        public bool FileUriMode;

        [Render(16)]
        public uint EmissionLimit;

        [Render(16)]
        public ListFormatKind ListFormat;

        [Render(1)]
        public FilePath TargetPath;
    }
}