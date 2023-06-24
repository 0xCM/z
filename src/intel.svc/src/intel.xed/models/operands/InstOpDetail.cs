//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct InstOpDetail : IComparable<InstOpDetail>
        {
            [Render(12)]
            public uint Pattern;

            [Render(18)]
            public XedInstClass InstClass;

            [Render(26)]
            public XedOpCode OpCode;

            [Render(6)]
            public MachineMode Mode;

            [Render(6)]
            public LockIndicator Lock;

            [Render(6)]
            public ModIndicator Mod;

            [Render(6)]
            public BitIndicator RexW;

            [Render(6)]
            public RepIndicator Rep;

            [Render(24)]
            public OpAttribs Attribs;

            [Render(8)]
            public byte OpCount;

            [Render(8)]
            public byte Index;

            [Render(8)]
            public OpName Name;

            [Render(8)]
            public OpKind Kind;

            [Render(8)]
            public OpAction Action;

            [Render(12)]
            public XedWidthCode WidthCode;

            [Render(12)]
            public GprWidth GrpWidth;

            [Render(12)]
            public bit Scalable;

            [Render(12)]
            public ushort BitWidth;

            [Render(16)]
            public ElementType ElementType;

            [Render(16)]
            public ushort ElementWidth;

            [Render(16)]
            public byte ElementCount;

            [Render(16)]
            public BitSegType SegInfo;

            [Render(8)]
            public Register RegLit;

            [Render(16)]
            public OpModifier Modifier;

            [Render(16)]
            public Visibility Visibility;

            [Render(32)]
            public Nonterminal Rule;

            [Render(1)]
            public asci64 SourceExpr;

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Rule.IsNonEmpty;
            }

            public bool IsRegLit
            {
                [MethodImpl(Inline)]
                get => RegLit.IsNonEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(InstOpDetail src)
                => new PatternOrder().Compare(this,src);

            public static InstOpDetail Empty => default;
        }
    }
}