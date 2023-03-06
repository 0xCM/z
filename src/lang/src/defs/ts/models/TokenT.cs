//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    partial class Ts
    {
        public sealed record class Token<T> : Expr<Token<T>>
            where T : INullity, IEquatable<T>, IHashed, new()
        {
            const string TypeDef = "export type {0} = '{1}'";
            
            const string ConstDef = "export const {0}:{0} = '{1}'";

            public @string Name;

            public T Value;

            public Token()
            {
                Name = @string.Empty;
                Value = new();
            }

            public Token(string name, T value)
            {
                Name = name;
                Value = value;
            }

            public override bool IsEmpty
                => Name.IsEmpty && Value.IsEmpty;

            public override Hash32 Hash
                => Name.Hash | Value.Hash;

            public override string Format()
            {
                var dst = text.emitter();
                
                var name = Name.Format()
                    .Replace(Chars.LParen, Chars.Underscore)
                    .Replace(Chars.RParen, Chars.Underscore)
                    .Replace(Chars.Dash, Chars.Underscore);
                
                var value = text.replace($"{Value}", Chars.BSlash, Chars.FSlash);
                dst.AppendLineFormat(TypeDef, name, value);
                dst.AppendLineFormat(ConstDef, name, value);
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            protected override bool Eq(Token<T> src)
                => Name == src.Name && Value.Equals(src.Value);
        }
    }
}