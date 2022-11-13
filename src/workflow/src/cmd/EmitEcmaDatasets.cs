//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct EmitEcmaDatasets : ICmd<EmitEcmaDatasets>
    {
        const string CmdName = "ecma-emit";

        public Timestamp JobId;

        public ReadOnlySeq<FileUri> Sources;

        public FolderPath Targets;     
    }
}