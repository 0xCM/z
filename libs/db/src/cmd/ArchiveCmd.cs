//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdId)]
    public record struct ArchiveCmd : IApiCmd<ArchiveCmd>
    {
        const string CmdId = "archive";

        public FS.FolderPath Source;

        public FilePath Target;
    }
}