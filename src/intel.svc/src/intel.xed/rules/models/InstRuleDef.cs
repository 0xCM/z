//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public record InstRuleDef : IComparable<InstRuleDef>
    {
        public XedInstForm Form;

        public Seq<CellValue> Cells;

        public InstBlockOperands Operands;

        public InstRuleDef()
        {
            Cells = sys.empty<CellValue>();
            Form = default;
            Operands = InstBlockOperands.Empty;
        }

        public string Format()
        {
            var dst = text.emitter();
            dst.Append($"{Form,-54} | ");
            for(var i=0; i<Cells.Count; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);            
                dst.Append(Cells[i]);
            }

            return dst.Emit();
        }

        public override string ToString()
            => Format();
        
        public int CompareTo(InstRuleDef src)
        {
            var result = Form.CompareTo(src.Form);
            if(result == 0)
            {
                result = Operands.Length.CompareTo(src.Operands.Length);
                if(result == 0)
                    result = Cells.Length.CompareTo(src.Cells.Length);
            }
            return result;
        }
    }
}