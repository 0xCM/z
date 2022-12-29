//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct GroupedToken
    {
        public readonly SymKey Key;

        public readonly @string Group;

        public readonly Identifier Type;

        public readonly Identifier Name;

        public readonly SymExpr Expr;

        public readonly SymVal Value;

        [MethodImpl(Inline)]
        public GroupedToken(SymKey key, @string group, Identifier type, Identifier name, SymExpr expr, SymVal value)
        {
            Key = key;
            Group = group;
            Type = type;
            Name = name;
            Expr = expr;
            Value = value;
        }

        public string Format()
            => string.Format("{0,-5} | {1,-36} | {2,-64} | {3,-64} | {4}", Key, Type, Name, RP.squote(Expr), Value);

        public override string ToString()
            => Format();
    }
}