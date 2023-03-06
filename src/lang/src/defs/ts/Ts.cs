//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    [ApiHost]
    public partial class Ts : Language<Ts>
    {        
        public static Token<@string> token(string name, @string value)
            => new (name,value);

        public Ts()
            :base("ts", "typescript")
        {

        }

        public Token<@string> DefineToken(string name, @string value)
            => token(name,value);
            
        public SourceFile Source(FilePath path, string content)
            => lang.source(LanguageName, path,content);
    }
}