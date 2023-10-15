//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [Record(TableName)]
    public record struct InstBlockOperand
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

        public string Format()
        {
            var dst = text.emitter();
            dst.Append(Name);
            if(Register.IsNonEmpty)
                dst.Append($":{Register}");
            else if(SegType.IsNonEmpty)
                dst.Append($":{SegType}");
            else if(Width.IsNonEmpty)
                dst.Append($":{Width}");
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}