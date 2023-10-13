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
                    pattern.Operands = (PatternOps)field;
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