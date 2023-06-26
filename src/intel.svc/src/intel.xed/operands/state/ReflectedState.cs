//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedRules
{
    public sealed class ReflectedState : PairedLookup<FieldKind,FieldInfo>
    {
        static FieldInfo[] fields = typeof(XedOperandState).DeclaredInstanceFields().Tagged<RuleFieldAttribute>();

        static Dictionary<FieldKind,FieldInfo> kinds = fields.Select(f => (f.Tag<RuleFieldAttribute>().Require().Kind,f)).ToDictionary();

        public ReflectedState()
            : base(kinds)
        {

        }

        public ConstLookup<FieldKind,object> Values<T>(in XedOperandState src)
            where T : unmanaged
        {
            var dst = dict<FieldKind,object>();
            foreach(var f in RightValues)
                dst.Add(this[f], f.GetValue(src));
            return dst;
        }
    }
}
