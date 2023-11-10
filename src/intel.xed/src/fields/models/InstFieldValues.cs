//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedRules
{
    public class InstFieldValues : Dictionary<string,string>
    {
        public readonly XedInstClass InstClass;

        public readonly XedInstForm InstForm;

        public InstFieldValues(XedInstClass @class, XedInstForm form, Dictionary<string,string> src)
            : base(src)
        {
            InstClass = @class;
            InstForm = form;
        }

        public string Format()
        {
            var keys = Keys.Array().Sort();            
            var dst = text.emitter();
            dst.Append(Chars.LBrace);
            for(var i=0; i<keys.Length; i++)
                dst.Append($"{keys[i]}:{this[keys[i]]}");
            dst.Append(Chars.RBrace);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
            
        public Index<FieldValue> ParseFields(out XedFieldState state)
            => XedFields.parse(this, out state);

        public static InstFieldValues Empty
            => new (XedInstClass.Empty, XedInstForm.Empty, dict<string,string>());
    }
}
