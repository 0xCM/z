//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    [ApiHost]
    public partial class lang
    {
        [Op]
        public static ILexer<CharSource,Token> splitter(char delimiter, Seq<char> buffer)
            => new Lexers.Splitter(delimiter, buffer);
    }
}