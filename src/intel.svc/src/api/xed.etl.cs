//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using static XedModels;
using static XedRules;
using static sys;

partial class XedCmd
{

    [CmdOp("xed/check/fields")]
    void CheckXedFields()
    {
        const string ReportFormat = "{0,-8} | {1,-64} | {2,-16} | {3,-16} | {4}";
        var headers = new string[]{"Seq", "Form", "Field", "Kind", "Value"};
        var instructions = XedTables.Instructions();
        var fields = Fields.allocate();    
        var report = text.emitter();
        report.AppendLineFormat(ReportFormat, headers);
        Span<FieldKind> members = stackalloc FieldKind[128];
        var counter = 0u;
        foreach(var def in instructions.Defs)
        {
            fields.Clear();
            members.Clear();
            var formexpr = $"{def.FormIndex} {def.Form}";
            var cells = def.Pattern.Body;
            var layout = EmptyString;
            for(var i=0; i<cells.Count; i++)
            {
                ref readonly var cell = ref cells[i];

                if(cell.Field == 0 || cell.CellKind == RuleCellKind.InstSeg)
                {
                    if(nonempty(layout))
                        layout += " ";

                    layout += $"{cell.Format()}";
                }
                else
                    report.AppendLineFormat(ReportFormat, counter++, formexpr, cell.Field, cell.CellKind, cell.Format());
            }
            if(nonempty(layout))
                report.AppendLineFormat(ReportFormat, counter++, formexpr, "", "Layout", layout);

            for(var i=0; i<def.Operands.Count; i++)
            {
                ref readonly var op = ref def.Operands[i];
                report.AppendLineFormat(ReportFormat, counter++, formexpr, "Operand", i, op.Format());
            }

            report.AppendLine();
            // var set = XedFields.pack(cells, fields);
            // var count = set.Members(members);
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var kind = ref members[i];
            //     var value = fields[kind];
            //     Channel.Row($"{kind}:{value}");                
            // }
        }
        Channel.FileEmit(report.Emit(), XedPaths.Imports().Path("xed.instblock.cells", FileKind.Csv));
    }

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
        var rules = XedTables.Instructions();
        XedImport.Emit(rules);
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}
