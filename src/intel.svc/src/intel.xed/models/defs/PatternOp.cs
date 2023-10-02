//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedRules;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct PatternOp : IComparable<PatternOp>
    {
        public uint PatternId;

        public byte Index;

        public OpName Name;

        public OpKind Kind;

        public OpAttribs Attribs;

        public @string SourceExpr;

        public PatternOp()
        {
            PatternId = 0u;
            Index = z8;
            Name = OpName.Empty;
            Kind = 0;
            Attribs = OpAttribs.Empty;
            SourceExpr = EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public bool IsReg
        {
            [MethodImpl(Inline)]
            get => Kind == OpKind.Reg || Kind == OpKind.Base || Kind == OpKind.Index || Kind == OpKind.Seg;
        }

        public bool IsNonTerminal
        {
            [MethodImpl(Inline)]
            get => Xed.nonterm(this, out _);
        }

        [MethodImpl(Inline)]
        public bool Nonterminal(out Nonterminal dst)
            => Xed.nonterm(this, out dst);

        [MethodImpl(Inline)]
        public bool RegLiteral(out Register dst)
            => Xed.reglit(this, out dst);

        [MethodImpl(Inline)]
        public bool WidthCode(out WidthCode dst)
            => Xed.widthcode(this, out dst);

        [MethodImpl(Inline)]
        public bool ElementType(out ElementType dst)
            => Xed.etype(this, out dst);

        [MethodImpl(Inline)]
        public bool Visibility(out Visibility dst)
            => Xed.visibility(this, out dst);

        [MethodImpl(Inline)]
        public bool Action(out OpAction dst)
            => Xed.action(this, out dst);

        [MethodImpl(Inline)]
        public bool Scale(out MemoryScale dst)
            => Xed.scale(this, out dst);

        [MethodImpl(Inline)]
        public bool Broadcast(out BroadcastKind dst)
            => Xed.broadcast(this, out dst);

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(PatternOp src)
        {
            var result = PatternId.CompareTo(src.PatternId);
            if(result == 0)
                result = Index.CompareTo(src.Index);
            return result;
        }

        public static PatternOp Empty => new();
    }
}
