//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static sys;

    class LexerCmd : WfAppCmd<LexerCmd>
    {
        [CmdOp("lexers/check")]
        void CheckLexers(CmdArgs args)
        {
            var source = FS.path(args[0].Value);
            using var chars = FS.chars(source);
            var buffer = new char[1024];
            var lexer = lang.splitter(' ', buffer);
            var tokens = lexer.Lex(chars);
            iter(tokens, t => Row(string.Format("{0:D5} {1}", t.Index, sys.@string(t.Expr))));

        }
    }
}