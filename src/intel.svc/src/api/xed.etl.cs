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

    [CmdOp("xed/check/bits")]
    void CheckBitfields()
    {
        // var pattern = BitPatterns.def<RexPrefix>();
        // var dst = text.emitter();
        // pattern.Symbolic(dst);
        // Channel.Row(dst.Emit());

        var a = num3.One;
        for(var i=0; i<50; i++)
        {
            a++;
            Channel.Row($"{(byte)a} | {a}");
        }

        
    }

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
        var rules = XedZ.instructions(lines.AsParallel()).Array().Sort();
        var operands = list<InstBlockOperand>();
        foreach(var pattern in rules)
        {   
            var count = pattern.Operands.Count;
            for(var i=0; i<count; i++)
            {
                operands.Add(pattern.Operands[i]);
            }
        }


        Channel.TableEmit(operands.ViewDeposited(), XedPaths.ImportTable<InstBlockOperand>());        
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}
