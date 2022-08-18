//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct PatternOpInfo
        {
            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAction Action;

            public OpWidthCode WidthCode;

            public GprWidth GprWidth;

            public ElementType ElementType;

            public BitSegType SegType;

            public ushort BitWidth;

            public ushort ElementWidth;

            public Register RegLit;

            public OpModifier Modifier;

            public Visibility Visibility;

            public Nonterminal NonTerminal;

            public bit IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => NonTerminal.IsNonEmpty;
            }

            public static PatternOpInfo Empty => default;
        }
    }
}