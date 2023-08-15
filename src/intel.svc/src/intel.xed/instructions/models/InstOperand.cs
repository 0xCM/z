//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [StructLayout(StructLayout,Pack=1), DataWidth(Width), Record(TableId)]
    public readonly struct InstOperand
    {
        const string TableId = "xed.inst.opatterns.ops";

        public const byte Width = num3.Width + OpName.Width + InstOpSymbol.Width + num8.Width + num16.Width;

        public readonly num3 Pos;

        public readonly OpName Name;

        public readonly InstOpSymbol Symbol;

        public readonly OpKind Kind;

        public readonly ushort Bits;

        [MethodImpl(Inline)]
        public InstOperand(num3 pos, OpName name, InstOpSymbol ind, OpKind kind, ushort width)
        {
            Kind = kind;
            Name = name;
            Pos = pos;
            Bits = width;
            Symbol = ind;
        }
    }
}
