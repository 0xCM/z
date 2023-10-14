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
    public static ReadOnlySeq<InstRuleDef> rules(ParallelQuery<InstBlockLineSpec> lines)
    {
        var patterns = list<InstRuleDef>();
        piter(lines, spec => {
            var field = BlockField.Empty;
            var mode = MachineMode.Default;
            var pattern = new InstRuleDef{
                Form = spec.Form
            };
            patterns.Add(pattern);
            foreach(var line in spec.Lines)
            {                
                if(XedZ.parse(line, out field))
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
                            pattern.Cells = segs.Array();
                        }
                        break;
                        case BlockFieldName.operands:
                        {
                            var ops = (PatternOps)field;
                            pattern.Operands = sys.alloc<InstRuleDef.Operand>(ops.Count);
                            for(var i=z8; i<ops.Count;i++)
                            {
                                ref var target = ref pattern.Operands[i];
                                ref readonly var op = ref ops[i];
                                target.Index = i;
                                target.Form = spec.Form;
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
                                {
                                    target.Width = new(target.Width.Code, XedWidths.width(target.Register));
                                }

                                if(target.Register.IsEmpty && op.Nonterminal(out var nt))
                                {   
                                    target.Register = nt;
                                }
                            }
                        }
                        break;
                    }            
                }
            }
        });
        return patterns.Array();
    }
}