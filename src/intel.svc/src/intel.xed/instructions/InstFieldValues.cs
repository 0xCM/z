//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedOps;

    partial class XedRules
    {
        public class InstFieldValues : Dictionary<string,string>
        {
            public static InstFieldValues define(XedInstClass @class, XedInstForm form, Index<Facet<string>> src)
            {
                var dst = dict<string,string>();
                for(var i=0; i<src.Count; i++)
                    dst.Add(src[i].Key, src[i].Value);
                return new InstFieldValues(@class, form, dst);
            }

            public readonly XedInstClass InstClass;

            public readonly XedInstForm InstForm;

            public InstFieldValues(XedInstClass @class, XedInstForm form, Dictionary<string,string> src)
                : base(src)
            {
                InstClass = @class;
                InstForm = form;
            }

            public Index<FieldValue> ParseFields(out XedOperandState state)
                => FieldParser.parse(this, out state);

            public static InstFieldValues Empty
                => new InstFieldValues(XedInstClass.Empty, XedInstForm.Empty, dict<string,string>());
        }
    }
}