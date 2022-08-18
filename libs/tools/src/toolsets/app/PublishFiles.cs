//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        public struct PublishFiles : IFlowCmd<FS.FolderPath,FS.FolderPath>
        {
            public Actor Actor;

            public FS.FolderPath Source;

            public FS.FolderPath Target;

            IActor IFlowCmd.Actor
                => Actor;

            FS.FolderPath IFlowCmd<FS.FolderPath, FS.FolderPath>.Source
                => Source;

            FS.FolderPath IFlowCmd<FS.FolderPath, FS.FolderPath>.Target
                => Target;
        }
    }
}