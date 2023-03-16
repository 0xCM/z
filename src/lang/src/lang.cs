//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    [ApiHost]
    public partial class lang
    {
        public static SourceFile source(@string lang, FilePath path, string content)
            => new SourceFile(lang,path,content);
            
        [Op]
        public static ref readonly Ts Ts
            => ref Ts.Instance;

        [Op]
        public static ILexer<CharSource,Token> splitter(char delimiter, Seq<char> buffer)
            => new Lexers.Splitter(delimiter, buffer);
    }
}