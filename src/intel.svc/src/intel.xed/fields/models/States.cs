//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;

partial class XedFields
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct States : IComparable<States>
    {
        public XedFieldState Fields;

        public Index<OpSpec> Ops;

        public AsmInfo Asm;

        public Index<FieldValue> FieldValues;

        [MethodImpl(Inline)]
        public bool Field(FieldKind kind, out FieldValue dst)
        {
            dst = FieldValue.Empty;
            for(var i=0; i<FieldValues.Count; i++)
            {
                ref readonly var f = ref FieldValues[i];
                if(f.Field == kind)
                {
                    dst = f;
                    break;
                }
            }
            return dst.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public int CompareTo(States src)
            => Asm.IP.CompareTo(src.Asm.IP);

        public static States Empty => default;
    }

}