//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        public static Index<Token> tokenize(Type src)
        {
            var symbols = untyped(src);
            var count = symbols.Length;
            var dst = alloc<Token>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref symbols[i];
                seek(dst,i) = new Token(symbol.Key,
                    text.ifempty(symbol.Group, EmptyString),
                    symbol.Type.Content,
                    symbol.Name,
                    text.ifempty(symbol.Expr.Text,symbol.Name),
                    symbol.Value
                    );
            }
            return dst;
        }
    }
}