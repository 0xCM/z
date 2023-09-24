//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    [DataWidth(Width)]
    public readonly struct OpName : IComparable<OpName>
    {
        public const byte Width = num5.Width;

        public readonly OpNameKind Kind;

        [MethodImpl(Inline)]
        public OpName(OpNameKind src)
        {
            Kind = src;
        }

        public InstOpSymbol Indicator
            => XedSigs.indicator(Kind);

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

        [MethodImpl(Inline)]
        public int CompareTo(OpName src)
            => Indicator.CompareTo(src.Indicator);

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OpName(OpNameKind src)
            => new OpName(src);

        [MethodImpl(Inline)]
        public static implicit operator OpNameKind(OpName src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator byte(OpName src)
            => (byte)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator OpName(byte src)
            => new OpName((OpNameKind)src);

        public static OpName Empty => default;
    }
}
