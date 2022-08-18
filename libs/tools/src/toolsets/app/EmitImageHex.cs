//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        [Cmd(CmdId,"Accepts a binary image and produces FileKind.Hex file")]
        public struct EmitImageHex : IFlowCmd<FS.FilePath,FS.FilePath>
        {
            const string CmdId = "image/emit/hex";

            public Actor Actor;

            public FS.FilePath Source;

            public FS.FilePath Target;

            IActor IFlowCmd.Actor
                => Actor;

            FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Source
                => Source;

            FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Target
                => Target;
        }
    }
}