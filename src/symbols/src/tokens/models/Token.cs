//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct Token : IToken
    {
        public readonly uint Index;

        readonly string _Name;

        readonly string _Expr;

        public Token()
        {
            Index = 0;
            _Name = EmptyString;
            _Expr = EmptyString;
        }

        [MethodImpl(Inline)]
        public Token(uint key, string name, string expr)
        {
            Index = key;
            _Name = name;
            _Expr = expr;
        }

        public ReadOnlySpan<char> Name
        {
            [MethodImpl(Inline)]
            get => _Name;
        }

        public ReadOnlySpan<char> Expr
        {
            [MethodImpl(Inline)]
            get => _Expr;
        }

        public static Token Empty => new Token();
    }
}