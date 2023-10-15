//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly record struct LogicClass : IComparable<LogicClass>
    {
        public static LogicClass Antecedant => new(LogicKind.Antecedant);

        public static LogicClass Operator => new(LogicKind.Operator);

        public static LogicClass Consequent => new(LogicKind.Consequent);

        public static LogicClass Empty => new(LogicKind.None);

        public readonly LogicKind Kind;

        [MethodImpl(Inline)]
        public LogicClass(LogicKind src)
        {
            Kind = src;
        }

        [MethodImpl(Inline)]
        public bool Equals(LogicClass src)
            => Kind == src.Kind;

        public override int GetHashCode()
            => (byte)this;

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LogicClass src)
            => Xed.cmp(Kind,src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator LogicClass(LogicKind src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator LogicKind(LogicClass src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator byte(LogicClass src)
            => (byte)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator LogicClass(byte src)
            => new ((LogicKind)src);
    }
}
