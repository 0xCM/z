//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class DumpBin
    {
        public enum CmdName : byte
        {
            None = 0,

            [Symbol("rawdata")]
            EmitRawData,

            [Symbol("loadconfig")]
            EmitLoadConfig,

            [Symbol("relocations")]
            EmitRelocations,

            [Symbol("exports")]
            EmitExports,

            [Symbol("disasm")]
            EmitAsm,

            [Symbol("headers")]
            EmitHeaders,
        }
    }
}