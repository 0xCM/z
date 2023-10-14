//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public record InstRuleDef
    {
        [Record(TableName)]
        public struct Operand
        {
            const string TableName = "xed.instblock.operands";

            [Render(64)]
            public XedInstForm Form;

            [Render(8)]
            public byte Index;

            [Render(8)]
            public OpName Name;

            [Render(8)]
            public OpKind Kind;

            [Render(12)]
            public OperandWidth Width;

            [Render(16)]
            public BitSegType SegType;

            [Render(16)]
            public Register Register;

            [Render(1)]
            public string SourceExpr;
        }

        public Seq<CellValue> Cells;

        public XedInstForm Form;

        public Seq<Operand> Operands;

        public InstRuleDef()
        {
            Cells = sys.empty<CellValue>();
            Form = default;
            Operands = sys.empty<Operand>();
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
    }
}