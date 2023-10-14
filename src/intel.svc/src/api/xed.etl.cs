//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using System.Linq;

using static sys;
using static XedModels;
using static XedRules;
using static XedZ;

partial class XedCmd
{
    XedImport XedImport => Wf.XedImport();

    [CmdOp("xed/ock")]
    void ListOcKinds()
    {
        var src = AsmOpCodes.info();
        iter(src, r => {
            Channel.RowFormat("{0} {1}", r.Name, r.Number);
        });
    }

    [CmdOp("xed/blocks")]
    void EmitBlockLines()
    {
        var lines =  XedZ.lines();
        var rules = XedZ.rules(lines.AsParallel());
        var operands = list<InstRuleDef.Operand>();
        foreach(var pattern in rules)
        {   
            var count = pattern.Operands.Count;
            for(var i=0; i<count; i++)
            {
                operands.Add(pattern.Operands[i]);
            }
        }


        Channel.TableEmit(operands.ViewDeposited(), XedPaths.ImportTable<InstRuleDef.Operand>());        
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}
