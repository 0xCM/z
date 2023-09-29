//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [DataWidth(num8.Width)]
    public readonly record struct InstIsa : IComparable<InstIsa>
    {
        public readonly InstIsaKind Kind;

        [MethodImpl(Inline)]
        public InstIsa(InstIsaKind mode)
        {
            Kind = mode;
        }

        public Identifier Name
            => XedRender.format(Kind);

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

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        public int CompareTo(InstIsa src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(InstIsa src)
            => Kind == src.Kind;

        public override int GetHashCode()
            => (int)Kind;

        [MethodImpl(Inline)]
        public static implicit operator InstIsa(InstIsaKind src)
            => new InstIsa(src);

        [MethodImpl(Inline)]
        public static implicit operator InstIsaKind(InstIsa src)
            => src.Kind;

        public static InstIsa Empty => default;
    }
}
