//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Build;
    
    [Cmd(CmdName)]
    public struct BuildProjectCmd : ICmd<BuildProjectCmd>
    {
        public const string CmdName = "build";

        public FilePath ProjectPath;

        public FilePath LogFile;

        public string Configuration;

        public string Platform;

        public LogVerbosity Verbosity;

        public uint MaxCpuCount;

        public bool Graph;
    }
}