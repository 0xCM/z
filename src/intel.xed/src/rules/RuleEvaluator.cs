//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
partial class XedRules
{
    public static FieldKind field(OpNameKind op)
    {
        var dst = FieldKind.INVALID;
        switch(op)
        {
            case OpNameKind.REG0:
                dst = FieldKind.REG0;
            break;
            case OpNameKind.REG1:
                dst = FieldKind.REG1;
            break;
            case OpNameKind.REG2:
                dst = FieldKind.REG2;
            break;
            case OpNameKind.REG3:
                dst = FieldKind.REG3;
            break;
            case OpNameKind.REG4:
                dst = FieldKind.REG4;
            break;
            case OpNameKind.REG5:
                dst = FieldKind.REG5;
            break;
            case OpNameKind.REG6:
                dst = FieldKind.REG6;
            break;
            case OpNameKind.REG7:
                dst = FieldKind.REG7;
            break;
            case OpNameKind.REG8:
                dst = FieldKind.REG8;
            break;
            case OpNameKind.REG9:
                dst = FieldKind.REG9;
            break;
            case OpNameKind.IMM0:
                dst = FieldKind.IMM0;
            break;
            case OpNameKind.IMM1:
                dst = FieldKind.IMM1;
            break;
            case OpNameKind.MEM0:
                dst = FieldKind.MEM0;
            break;
            case OpNameKind.MEM1:
                dst = FieldKind.MEM1;
            break;
            case OpNameKind.RELBR:
                dst = FieldKind.RELBR;
            break;
            case OpNameKind.BASE0:
                dst = FieldKind.BASE0;
            break;
            case OpNameKind.BASE1:
                dst = FieldKind.BASE1;
            break;
            case OpNameKind.SEG0:
                dst = FieldKind.SEG0;
            break;
            case OpNameKind.SEG1:
                dst = FieldKind.SEG1;
            break;
            case OpNameKind.AGEN:
                dst = FieldKind.AGEN;
            break;
            case OpNameKind.PTR:
                dst = FieldKind.PTR;
            break;
            case OpNameKind.INDEX:
                dst = FieldKind.INDEX;
            break;
            case OpNameKind.SCALE:
                dst = FieldKind.SCALE;
            break;
            case OpNameKind.DISP:
                dst = FieldKind.DISP;
            break;
        }

        return dst;
    }
    public class RuleEvaluator
    {
        public readonly CellTable Rule;

        public readonly InstBlockOperands Operands;

        public RuleEvaluator(CellTable rule, InstBlockOperands ops)
        {
            Rule = rule;
            Operands = ops;
        }

        public void Update(ref XedFieldState state)
        {
            for(var i=0; i<Rule.RowCount; i++)
            {
                ref readonly var row = ref Rule.Rows[i];
                var antecedants = row.Antecedants();
                for(var j=0; j<antecedants.Length; j++)
                {
                    ref readonly var antecedant = ref antecedants[j];
                    var current = XedFields.extract(state, antecedant.Field);
                    ref readonly var value = ref antecedant.Value;
                    var field = new FieldValue(antecedant.Field, value.AsHex16());
                    XedFields.update(field, ref state);
                }            
            }

            for(var i=0; i<Operands.Count; i++)
            {
                ref readonly var op = ref Operands[i];
                ref readonly var name = ref op.Name;
                
            }
        }
    }
}