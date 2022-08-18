//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Token<K>
        where K : unmanaged
    {
        public readonly K Kind;

        public readonly SymKey Key;

        public readonly @string Group;

        public readonly Identifier Type;

        public readonly Identifier Name;

        public readonly SymExpr Expr;

        public readonly SymVal Value;

        [MethodImpl(Inline)]
        public Token(K kind, SymKey key, @string group, Identifier type, Identifier name, SymExpr expr, SymVal value)
        {
            Kind = kind;
            Key = key;
            Group = group;
            Type = type;
            Name = name;
            Expr = expr;
            Value = value;
        }

        public Token Untyped()
            => new Token(Key, Group, Type, Name, Expr, Value);

        public string Format()
            => string.Format("{0,-5} | {1,-36} | {2,-64} | {3,-64} | {4}", Key, Type, Name, RpOps.squote(Expr), Value);

        public override string ToString()
            => Format();
    }
}