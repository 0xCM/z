//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static XedRules;
using static sys;

using N = XedZ.BlockFieldName;

partial class XedZ
{            
    public static InstBlockPattern pattern(in InstBlockLineSpec spec)
    {
        var pattern = new InstBlockPattern();
        var fields = list<BlockField>();
        foreach(var field in XedZ.fields(spec))
        {                
            fields.Add(field);
            switch(field.Name)
            {
                case N.iclass:
                    pattern.Instruction = (XedInstClass)field;
                    break;
                case N.iform:
                    pattern.Form = (XedInstForm)field;
                    break;
                case N.mode_restriction:
                    pattern.Mode = (MachineMode)field;
                break;
                case N.opcode:
                case N.amd_3dnow_opcode:
                    pattern.OpCode = (Hex8)field;
                break;
                case N.attributes:
                    pattern.InstAttribs = (InstAttribs)field;
                break;
                case N.operands:
                {
                    var ops = (PatternOps)field;
                    pattern.Operands = new(sys.alloc<InstBlockOperand>(ops.Count));
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
                            target.Width = new(wc, XedWidths.bitwidth(pattern.Mode,wc));
                            var wi = XedWidths.describe(target.Width);
                            if(wi.ElementCount > 1 && wi.ElementWidth != 0)
                                target.SegType = wi.SegType;
                        }

                        if(target.Register.IsNonEmpty && !target.Register.IsNonterminal && target.Width.Bits == 0)
                            target.Width = new(target.Width.Code, XedWidths.width(target.Register));

                        if(target.Register.IsEmpty && op.Nonterminal(out var nt))
                            target.Register = nt;
                    }
                    //pattern.Operands = (PatternOps)field;
                }
                break;
                case N.pattern:
                {
                    pattern.Body = (InstCells)field;
                    var cells = pattern.Body;
                    var segexpr = EmptyString;
                    for(var i=0; i<cells.Count; i++)
                    {
                        ref readonly var cell = ref cells[i];
                        switch(cell.CellKind)
                        {
                            case RuleCellKind.InstSeg:
                            {
                                if(nonempty(segexpr))
                                    segexpr += " ";
                                segexpr += cell.AsInstSeg();
                            }
                            break;
                            case RuleCellKind.HexLit:
                            {
                                if(nonempty(segexpr))
                                    segexpr += " ";
                                    
                                segexpr += "0x";
                                segexpr += cell.AsHexLit();
                            }                                    
                            break;
                            case RuleCellKind.BitLit:
                                if(nonempty(segexpr))
                                    segexpr += " ";
                                segexpr += cell.AsBitLit();
                            break;
                        }
                    }
                }
                break;
            }
        }
        return pattern;
    }
}