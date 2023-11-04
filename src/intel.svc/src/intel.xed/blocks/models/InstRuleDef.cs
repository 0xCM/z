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

        public InstBlockPattern Pattern;
        
        public ReadOnlySeq<InstBlockField> Fields;
        
        public ReadOnlySeq<CellValue> Cells;

        public InstBlockOperands Operands;

        readonly InstBlockField EmptyField = InstBlockField.Empty;

        public InstRuleDef()
        {
            Cells = sys.empty<CellValue>();
            Fields = sys.empty<InstBlockField>();
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

        public ref readonly InstBlockField Field(BlockFieldName name)
        {
            for(var i=0; i<Fields.Count; i++)
            {
                ref readonly var field = ref Fields[i];
                if(field.Name == name)
                    return ref field;
            }

            return ref EmptyField;
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