//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public class Lexers
    {        
        public sealed class Splitter : Lexer<Splitter,CharSource,Token>
        {
            readonly char Delimiter;

            readonly Seq<char> Buffer;

            int Pos;

            public Splitter(char delimiter, Seq<char> buffer)
            {
                Delimiter = delimiter;
                Buffer = buffer;
                Pos = 0;
            }

            public override LexerKind Kind 
                => default;

            public override IEnumerable<Token> Lex(CharSource src)
            {
                var c = AsciNone;
                var index = 0u;
                while(src.Next(out c))
                {
                    if(c == Delimiter)
                    {
                        if(Pos != 0)
                        {
                            yield return new Token(index, $"{index}", sys.@string(sys.slice(Buffer.View,0,Pos)));
                            Pos = -1;
                            index++;
                        }
                    }
                    Buffer[Pos++] = c;
                }
            }
        }
    }
}