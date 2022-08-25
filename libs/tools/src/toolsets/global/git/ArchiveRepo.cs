//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdId)]
    public struct ArchiveRepo : IFlowCmd<FolderPath,FilePath>
    {
        const string CmdId = "repo/archive";

        public Actor Actor;

        public FolderPath Source;

        public FilePath Target;

        FolderPath IFlowCmd<FolderPath, FilePath>.Source
            => Source;

        FilePath IFlowCmd<FolderPath, FilePath>.Target
            => Target;

        IActor IFlowCmd.Actor
            => Actor;
    }
}