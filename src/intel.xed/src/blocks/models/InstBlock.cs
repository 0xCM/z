//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public record InstBlock : IComparable<InstBlock>
    {
        public XedInstForm Form;

        public byte FormIndex;
        
        public InstBlockPattern Pattern;
        
        public ReadOnlySeq<InstBlockField> Fields;
        
        public InstBlockOperands Operands;

        readonly InstBlockField EmptyField = InstBlockField.Empty;

        public InstBlock()
        {
            Fields = sys.empty<InstBlockField>();
            Form = default;
            Operands = InstBlockOperands.Empty;
        }

        public string Format()
        {
            var dst = text.emitter();
            dst.Append($"{Form,-54} | ");
            for(var i=0; i<Pattern.Body.Data.Count; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);            
                dst.Append(Pattern.Body.Data[i]);
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
        
        public int CompareTo(InstBlock src)
        {
            var result = Form.CompareTo(src.Form);
            if(result == 0)
                result = FormIndex.CompareTo(src.FormIndex);
            return result;
        }
    }
}