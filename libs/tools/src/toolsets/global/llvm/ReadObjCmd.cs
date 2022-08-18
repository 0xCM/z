//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(ToolNames.llvm_readobj), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ReadObjCmd : IToolFlowCmd<ReadObjCmd>
    {
        [CmdArg("<src>")]
        public FS.FilePath Source;

        [CmdArg("<dst>")]
        public FS.FilePath Target;

        [CmdFlag("--coff-tls-directory")]
        public bit CoffTlsDirectory;

        [CmdFlag("--dynamic-table")]
        public bit DynamicTable;

        [CmdFlag("--file-header")]
        public bit FileHeader;

        [CmdFlag("--histogram")]
        public bit Histogram;

        [CmdFlag("--notes")]
        public bit Notes;

        [CmdFlag("--program-headers")]
        public bit ProgramHeaders;

        [CmdFlag("--relocations")]
        public bit Relocations;

        [CmdFlag("--section-groups")]
        public bit SectionGroups;

        [CmdFlag("--section-details")]
        public bit SectionDetails;

        [CmdFlag("--section-data")]
        public bit SectionData;

        [CmdFlag("--section-headers")]
        public bit SectionHeaders;

        [CmdFlag("--section-mapping")]
        public bit SectionMapping;

        [CmdFlag("--symbols")]
        public bit Symbols;

        [CmdFlag("--unwind")]
        public bit Unwind;

        [CmdFlag("--version-info")]
        public bit VersionInfo;

        FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Source
            => Source;

        FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Target
            => Target;
    }
}