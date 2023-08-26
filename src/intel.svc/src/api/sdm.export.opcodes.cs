//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmCmd
{
    [CmdOp("sdm/export/opcodes")]
    void ExportOpCodes()
    {
        Sdm.ExportOpCodes();
    }
   
}
