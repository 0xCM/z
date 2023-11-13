//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;
using System.Linq;

using static XedRules;
using static XedModels;
using static sys;

partial class XedCmd
{
    [CmdOp("xed/gen")]
    void Gen()
    {
        var context = XedMachines.context();
        var dst = text.emitter();
        XedMachines.gen(context,dst);
        Channel.FileEmit(dst.Emit(), FS.path("D:/env/dev/z0/src/intel.svc/src/intel.xed/gen/XedMachine.cs"));
    }

    void PrintRegSelect(IEnumerable<RegSelect> selectors)
    {
        var dst = text.emitter();
        var max = 0u;
        foreach(var selector in selectors)
        {
            if(selector.RowWidth > max)
                max = selector.RowWidth;

            dst.AppendLine($"{selector.Rule}:{selector.RowCount}x{selector.ColCount}");
            dst.AppendLine(RP.PageBreak120);
            var cols = selector.Cols;
            for(var i=0; i<cols.Count; i++)
            {
                if(i !=0)
                    dst.Append(" | ");

                dst.Append($"{cols[i],-12}");
            }
            dst.Append(" | Register");
            dst.AppendLine();
            for(var i=0u; i<selector.RowCount; i++)            
            {                
                for(var j=0; j<selector.ColCount; j++)
                {
                    ref readonly var col = ref cols[j];
                    ref readonly var predicate = ref selector[i,col];
                    
                    var bits = EmptyString;
                    switch(selector.ColWidth(col))
                    {
                        case 1:
                        {
                            var reduced = predicate != 0;
                            bits = reduced.Format();
                        }
                        break;
                        
                        case 2:
                        {
                            var reduced = (num2)predicate;
                            bits = reduced.Bitstring();
                        }
                        break;
                        case 3:
                        {
                            var reduced = (num3)predicate;
                            bits = reduced.Bitstring();
                        }
                        break;
                        case 4:
                        {
                            var reduced = (num4)predicate;
                            bits = reduced.Bitstring();
                        }
                        break;
                        case 5:
                        {
                            var reduced = (num5)predicate;
                            bits = reduced.Bitstring();
                        }
                        break;
                    }
                    if(j != 0)
                        dst.Append(" | ");

                    dst.Append($"{bits,-12}");
                }

                dst.Append(" | ");
                var reg = selector.Register(i);
                if(reg.IsExpr)
                {
                    var regval = reg.AsCellExpr().Value;
                        dst.AppendLine(regval);
                }
                else
                    dst.AppendLine(reg);
            }
            Channel.Row(dst.Emit());
        }
    }

    [CmdOp("xed/regselect")]
    void CreateRegSelect()
    {
        var src = RegSelect.selectors();
        var state = XedFieldState.Empty;
        for(var i=z8; i<=1; i++)
        for(var j=z8; j<=1; j++)
        for(var k=z8; k<=7; k++)
        {
            state.REXRR = i;
            state.REXR = j;
            state.REG = k;
            var selector = src[(RuleTableKind.DEC, RuleName.ZMM_R3_64)];
            var reg =  selector.Evaluate(state);
            Channel.Row(reg);
        }   
    }

}