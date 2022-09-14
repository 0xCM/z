//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct EcmaEmissionCmd : IToolCmd<Zsh,EcmaEmissionCmd>
    {
        const string CmdName = "emit.ecma.metadata";

        public Timestamp JobId;

        public ReadOnlySeq<FileUri> Sources;

        public FolderPath Targets;

        public EcmaEmissionSettings Settings;
    }
}