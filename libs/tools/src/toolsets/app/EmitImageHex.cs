//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        [Cmd(CmdId,"Accepts a binary image and produces FileKind.Hex file")]
        public struct EmitImageHex : IFlowCmd<FilePath,FilePath>
        {
            const string CmdId = "image/emit/hex";

            public Actor Actor;

            public FilePath Source;

            public FilePath Target;

            IActor IFlowCmd.Actor
                => Actor;

            FilePath IFlowCmd<FilePath, FilePath>.Source
                => Source;

            FilePath IFlowCmd<FilePath, FilePath>.Target
                => Target;
        }
    }
}