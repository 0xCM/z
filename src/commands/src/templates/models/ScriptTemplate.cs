//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ScriptTemplate : PText
    {
        public static ScriptTemplate create(string name, string content)
            => new ScriptTemplate(name, content);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(ScriptTemplate src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(ScriptTemplate src, CmdVars vars)
            => new CmdScriptExpr(src, vars);

        public string Name {get;}

        [MethodImpl(Inline)]
        public ScriptTemplate(TextBlock pattern)
            : base(pattern)
        {
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public ScriptTemplate(string name, TextBlock pattern)
            : base(pattern)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator ScriptTemplate(string src)
            => new ScriptTemplate(src);

        [MethodImpl(Inline)]
        public static implicit operator ScriptTemplate(Pair<string> src)
            => new ScriptTemplate(src.Left, src.Right);

        public static ScriptTemplate Empty
            => new ScriptTemplate(EmptyString, EmptyString);
    }
}