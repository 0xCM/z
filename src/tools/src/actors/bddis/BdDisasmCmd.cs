//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct BdDisasmCmd
    {
        public FilePath ToolPath;

        public FilePath BinPath;

        public Bitness AsmBitMode;

        public bool EmitBitfields;

        public bool EmitDetails;

        public FilePath OutputPath;

        public string CmdName
        {
            get => nameof(BdDisasmCmd);
        }
    }
}