//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static XedRules;
using static sys;

partial class XedZ
{            
    static InstRuleDef instruction(XedInstForm form, IEnumerable<BlockField> fields)
    {
        var mode = MachineMode.Default;
        var rule = new InstRuleDef{
            Form = form
        };

        foreach(var field in fields)
        {
            switch(field.Name)                
            {
                case BlockFieldName.mode_restriction:
                    mode = (MachineMode)field;
                break;
                case BlockFieldName.pattern:
                {
                    var cells = (InstCells)field;
                    var segs = list<CellValue>();
                    var segexpr = EmptyString;
                    for(var i=0; i<cells.Count; i++)
                    {
                        ref readonly var cell = ref cells[i];
                        switch(cell.CellKind)
                        {
                            case RuleCellKind.BitLit:
                            case RuleCellKind.HexLit:
                            case RuleCellKind.InstSeg:
                                segs.Add(cell);
                            break;
                        }
                    }
                    rule.Cells = segs.Array();
                }
                break;
                case BlockFieldName.operands:
                {
                    var ops = (PatternOps)field;
                    rule.Operands = new(sys.alloc<InstBlockOperand>(ops.Count));
                    for(var i=z8; i<ops.Count;i++)
                    {
                        ref var target = ref rule.Operands[i];
                        ref readonly var op = ref ops[i];
                        target.Index = i;
                        target.Form = form;
                        target.Name = op.Name;
                        target.Kind = op.Kind;
                        target.SourceExpr = op.SourceExpr;
                        op.WidthCode(out var wc);
                        op.RegLiteral(out target.Register);
                        if(wc != 0)
                        {
                            target.Width = new(wc, XedWidths.bitwidth(mode,wc));
                            var wi = XedWidths.describe(target.Width);
                            if(wi.ElementCount > 1 && wi.ElementWidth != 0)
                                target.SegType = wi.SegType;
                        }

                        if(target.Register.IsNonEmpty && !target.Register.IsNonterminal && target.Width.Bits == 0)
                            target.Width = new(target.Width.Code, XedWidths.width(target.Register));

                        if(target.Register.IsEmpty && op.Nonterminal(out var nt))
                            target.Register = nt;
                    }
                }
                break;
            }                             
        }
        return rule;
    }

    public static ParallelQuery<InstRuleDef> instructions(ParallelQuery<InstBlockLineSpec> lines)
    {
        var query = from line in lines
                    let f = fields(line)
                    select instruction(line.Form,f);    
        return query;
    }

}