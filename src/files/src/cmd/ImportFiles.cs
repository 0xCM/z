//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CmdName)]
    public sealed record class ImportFiles : Command<ImportFiles>
    {
        const string CmdName = "files/import";

        public readonly FolderPath source;

        public readonly FolderPath project;

        public ImportFiles(FolderPath src, FolderPath dst)
        {
            source = src;
            project = dst;
        }

        public ImportFiles()
        {
            source = FolderPath.Empty;
            project = FolderPath.Empty;
        }
    }
}