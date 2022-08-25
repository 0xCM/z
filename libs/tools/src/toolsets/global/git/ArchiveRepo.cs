//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdId)]
    public struct ArchiveRepo : IFlowCmd<FS.FolderPath,FilePath>
    {
        const string CmdId = "repo/archive";

        public Actor Actor;

        public FS.FolderPath Source;

        public FilePath Target;

        FS.FolderPath IFlowCmd<FS.FolderPath, FilePath>.Source
            => Source;

        FilePath IFlowCmd<FS.FolderPath, FilePath>.Target
            => Target;

        IActor IFlowCmd.Actor
            => Actor;
    }
}