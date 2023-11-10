//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(Width)]
    public readonly record struct Nonterminal : IEquatable<Nonterminal>, IComparable<Nonterminal>
    {
        public const byte Width = num9.Width;

        public static DataSize DataSize => (Width,sys.width<RuleName>());

        public readonly RuleName Name;

        public Nonterminal(RuleName name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(Nonterminal src)
            => Name == src.Name;

        public override int GetHashCode()
            => (ushort)Name;

        public int CompareTo(Nonterminal src)
            => Format().CompareTo(src.Format());

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        public static explicit operator ushort(Nonterminal src)
            => (ushort)src.Name;

        [MethodImpl(Inline)]
        public static explicit operator Nonterminal(ushort src)
            => new ((RuleName)src);

        [MethodImpl(Inline)]
        public static implicit operator RuleName(Nonterminal src)
            => src.Name;

        [MethodImpl(Inline)]
        public static implicit operator Nonterminal(RuleName src)
            => new (src);

        public static Nonterminal Empty => default;
    }
}
