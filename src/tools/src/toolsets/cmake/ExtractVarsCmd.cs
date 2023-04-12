//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools.CMake
{
    [Cmd(CmdName)]
    public record class ExtractVarsCmd : Command<ExtractVarsCmd>
    {
        public const string CmdName = "cmake/buildvars";

        public FolderPath BuildRoot;

        public FilePath Target;   
    }
}