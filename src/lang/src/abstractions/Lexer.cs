//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public abstract class Lexer : ILexer
    {
        public abstract LexerKind Kind {get;}
    }

    public abstract class Lexer<L> : Lexer
        where L : Lexer<L>
    {

    }

    public abstract class Lexer<L,T> : Lexer<L>, ILexer<T>
        where L : Lexer<L,T>
        where T : IToken, new()
    {


    }

    public abstract class Lexer<L,S,T> : Lexer<L,T>, ILexer<S,T>
        where L : Lexer<L,S,T>
        where T : IToken, new()
        where S : ITokenSource
    {

        public abstract IEnumerable<T> Lex(S src);
    }
}