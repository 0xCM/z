//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmCmd
{
    [CmdOp("sdm/inst")]
    void ShowInstInfo(CmdArgs args)
    {
        var tables = Sdm.LoadCsvTables();
        foreach(var table in tables)
        {
            foreach(var oc in Sdm.CalcOpCodes(table))
            {
                Channel.RowFormat("{0,-16} {1}", oc.Mnemonic, oc.OpCodeExpr);
            }
        }

    }
}
