//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        public struct PublishFiles : IFlowCmd<FolderPath,FolderPath>
        {
            public Actor Actor;

            public FolderPath Source;

            public FolderPath Target;

            IActor IFlowCmd.Actor
                => Actor;

            FolderPath IFlowCmd<FolderPath, FolderPath>.Source
                => Source;

            FolderPath IFlowCmd<FolderPath, FolderPath>.Target
                => Target;
        }
    }
}