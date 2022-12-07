//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PScript : PText
    {
        public static void validate()
        {
            const string Pattern = "{0} {1} {2} {3}({4},{5});";
            var result = Outcome.Success;
            PText.define(Pattern, "public", "static", "uint", "f", "x", "y");

            var dst = new PTextVar("dst");
            var src1 = new PTextVar("src1");
            var src2 = new PTextVar("src2");
            var body = string.Format("{0}, {1}, {2}", dst, src1, src2);
            var x = PTextExpr.init(body);
            var vars = x.Vars;
            Require.equal(vars.Length,3);
            x["dst"] = new PTextVar("dst", (Identifier)"abc");
            x["src1"] = new PTextVar("src1", (Identifier)"def");
            x["src2"] = new PTextVar("src2", (Identifier)"hij");

            var _result = x.Eval();
            Require.equal("abc, def, hij", _result);

        }

        public static PScript create(string name, string content)
            => new PScript(name, content);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(PScript src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(PScript src, CmdVars vars)
            => new CmdScriptExpr(src, vars);

        public string Name {get;}

        [MethodImpl(Inline)]
        public PScript(TextBlock pattern)
            : base(pattern)
        {
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public PScript(string name, TextBlock pattern)
            : base(pattern)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator PScript(string src)
            => new PScript(src);

        [MethodImpl(Inline)]
        public static implicit operator PScript(Pair<string> src)
            => new PScript(src.Left, src.Right);

        public static PScript Empty
            => new PScript(EmptyString, EmptyString);
    }
}