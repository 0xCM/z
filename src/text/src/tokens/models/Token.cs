//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Token
    {
        public readonly SymKey Key;

        public readonly @string Group;

        public readonly Identifier Type;

        public readonly Identifier Name;

        public readonly SymExpr Expr;

        public readonly SymVal Value;

        [MethodImpl(Inline)]
        public Token(SymKey key, @string group, Identifier type, Identifier name, SymExpr expr, SymVal value)
        {
            Key = key;
            Group = group;
            Type = type;
            Name = name;
            Expr = expr;
            Value = value;
        }

        [MethodImpl(Inline)]
        public Token<K> WithKind<K>(K kind)
            where K : unmanaged
                => new Token<K>(kind, Key, Group, Type, Name, Expr, Value);

        public string Format()
            => string.Format("{0,-5} | {1,-36} | {2,-64} | {3,-64} | {4}", Key, Type, Name, RP.squote(Expr), Value);

        public override string ToString()
            => Format();
    }
}