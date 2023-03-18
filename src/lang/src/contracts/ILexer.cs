//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILexer
    {
        LexerKind Kind {get;}   
    }

    public interface ILexer<T> : ILexer
        where T : IToken, new()
    {
    }

    public interface ILexer<S,T> : ILexer<T>
        where T : IToken, new()
        where S : ITokenSource
    {
        IEnumerable<T> Lex(S src);
    }

    [StructLayout(LayoutKind.Sequential,Size=8)]
    public struct LexerKind
    {

    }

}