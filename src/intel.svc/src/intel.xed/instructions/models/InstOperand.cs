//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public readonly struct InstOperand
    {
        const string TableId = "xed.inst.opatterns.ops";

        public readonly num3 Pos;

        public readonly OpName Name;

        public readonly InstOpSymbol Symbol;

        public readonly OpKind Kind;

        public readonly ushort Width;

        [MethodImpl(Inline)]
        public InstOperand(num3 pos, OpName name, InstOpSymbol ind, OpKind kind, ushort width)
        {
            Kind = kind;
            Name = name;
            Pos = pos;
            Width = width;
            Symbol = ind;
        }
    }
}
