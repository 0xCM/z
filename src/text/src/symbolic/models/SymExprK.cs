//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymExpr<K>
    {
        public readonly K Kind;

        public readonly SymExpr Symbol;

        [MethodImpl(Inline)]
        public SymExpr(K kind, SymExpr symbol)
        {
            Kind = kind;
            Symbol = symbol;
        }

        public ushort CharCount
        {
            [MethodImpl(Inline)]
            get => Symbol.CharCount;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsEmpty;
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Symbol.Text;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Symbol.Data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Symbol.Format();

        [MethodImpl(Inline)]
        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Symbol.GetHashCode();

        public bool Equals(SymExpr<K> src)
            => Symbol.Equals(src.Symbol);

        public override bool Equals(object src)
            => src is SymExpr e && Equals(e);

        [MethodImpl(Inline)]
        public static implicit operator SymExpr(SymExpr<K> src)
            => new SymExpr(src.Symbol.Text);

        [MethodImpl(Inline)]
        public static implicit operator SymExpr<K>((K kind, string sym) src)
            => new SymExpr<K>(src.kind, src.sym);
    }
}