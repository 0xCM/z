//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

using K = XedModels.OpAttribKind;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(Width)]
    public readonly record struct OpAttrib : IComparable<OpAttrib>, IEquatable<OpAttrib>
    {
        public const byte Width = KindWidth + num16.Width;

        public const byte KindWidth = num4.Width;

        public readonly K Kind;

        readonly ushort Data;

        [MethodImpl(Inline)]
        internal OpAttrib(K kind, ushort data)
        {
            Kind = kind;
            Data = data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0 && Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0 || Data != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Hash32)(uint)Kind | (Hash32)Data;
        }

        [MethodImpl(Inline)]
        public int CompareTo(OpAttrib src)
            => ((uint)Kind).CompareTo((uint)src.Kind);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(OpAttrib src)
            => Kind == src.Kind && Data == src.Data;

        [MethodImpl(Inline)]
        public OpModifier ToModifier()
            => new OpModifier((OpModKind)Data);

        [MethodImpl(Inline)]
        public OpAction ToAction()
            => (OpAction)Data;

        [MethodImpl(Inline)]
        public WidthCode ToWidthCode()
            => (WidthCode)Data;

        [MethodImpl(Inline)]
        public XedRegId ToRegLiteral()
            => (XedRegId)Data;

        [MethodImpl(Inline)]
        public Nonterminal ToNonTerm()
            => (RuleName)Data;

        [MethodImpl(Inline)]
        public MemoryScale ToScale()
            => (MemoryScale)(ScaleFactor)Data;

        [MethodImpl(Inline)]
        public ElementType ToElementType()
            => (ElementType)Data;

        [MethodImpl(Inline)]
        public Visibility ToVisibility()
            => (OpVisibility)Data;

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(OpAction src)
            => new (K.Action, (ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(WidthCode src)
            => new (K.Width, (ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(Nonterminal src)
            => new (K.Nonterminal, (ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(XedRegId src)
            => new (K.RegLiteral, (ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(ElementType src)
            => new (K.ElementType, (ushort)src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(OpVisibility src)
            => new (K.Visibility, (ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(OpModKind src)
            => new (K.Modifier, (ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(OpModifier src)
            => new (K.Modifier, (ushort)src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator OpAttrib(MemoryScale src)
            => new (K.Scale, (ushort)src.Factor);

        public static OpAttrib Empty => default;
    }
}
