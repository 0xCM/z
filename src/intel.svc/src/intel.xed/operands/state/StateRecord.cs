//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

    using static XedModels;

partial class XedRules
{
    partial class OperandStates
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct StateRecord : IComparable<StateRecord>
        {
            public XedOperandState State;

            public Index<OpSpec> Ops;

            public AsmInfo Asm;

            public Index<FieldValue> Fields;

            [MethodImpl(Inline)]
            public bool Field(FieldKind kind, out FieldValue dst)
            {
                dst = FieldValue.Empty;
                for(var i=0; i<Fields.Count; i++)
                {
                    ref readonly var f = ref Fields[i];
                    if(f.Field == kind)
                    {
                        dst = f;
                        break;
                    }
                }
                return dst.IsNonEmpty;
            }

            [MethodImpl(Inline)]
            public int CompareTo(StateRecord src)
                => Asm.IP.CompareTo(src.Asm.IP);

            public static StateRecord Empty => default;
        }
    }
}
