//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ScriptPattern : VarPatterns
    {
        public static void validate()
        {
            const string Pattern = "{0} {1} {2} {3}({4},{5});";
            var result = Outcome.Success;
            VarPatterns.pattern(Pattern, "public", "static", "uint", "f", "x", "y");

            var dst = new PatternTextVar("dst");
            var src1 = new PatternTextVar("src1");
            var src2 = new PatternTextVar("src2");
            var body = string.Format("{0}, {1}, {2}", dst, src1, src2);
            var x = PatternTextExpr.init(body);
            var vars = x.Vars;
            Require.equal(vars.Length,3);
            x["dst"] = new PatternTextVar("dst", (Identifier)"abc");
            x["src1"] = new PatternTextVar("src1", (Identifier)"def");
            x["src2"] = new PatternTextVar("src2", (Identifier)"hij");

            var _result = x.Eval();
            Require.equal("abc, def, hij", _result);
        }

        public static ScriptPattern create(string name, string content)
            => new ScriptPattern(name, content);

        [MethodImpl(Inline), Op]
        public static CmdVarExpr expr(ScriptPattern src)
            => new CmdVarExpr(src);

        [MethodImpl(Inline), Op]
        public static CmdVarExpr expr(ScriptPattern src, CmdVars vars)
            => new CmdVarExpr(src, vars);

        public string Name {get;}

        [MethodImpl(Inline)]
        public ScriptPattern(TextBlock pattern)
            : base(pattern)
        {
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public ScriptPattern(string name, TextBlock pattern)
            : base(pattern)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern(string src)
            => new ScriptPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern(Pair<string> src)
            => new ScriptPattern(src.Left, src.Right);

        public static ScriptPattern Empty
            => new ScriptPattern(EmptyString, EmptyString);
    }
}