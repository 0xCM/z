//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class TextParametrics
    {
        public Outcome Check1()
        {
            const string Pattern = "{0} {1} {2} {3}({4},{5});";
            var result = Outcome.Success;
            template(Pattern, "public", "static", "uint", "f", "x", "y");
            return true;
        }

        [Op]
        public void CheckTextExpr()
        {
            var dst = new TextTemplateVar("dst");
            var src1 = new TextTemplateVar("src1");
            var src2 = new TextTemplateVar("src2");
            var body = string.Format("{0}, {1}, {2}", dst, src1, src2);
            var x = TextTemplateExpr.init(body);
            var vars = x.Vars;
            Require.equal(vars.Length,3);
            x["dst"] = new TextTemplateVar("dst", (Identifier)"abc");
            x["src1"] = new TextTemplateVar("src1", (Identifier)"def");
            x["src2"] = new TextTemplateVar("src2", (Identifier)"hij");

            var result = x.Eval();
            Require.equal("abc, def, hij", result);
        }

        public static CmdScriptExpr format(ScriptTemplate pattern, params CmdVar[] args)
            => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        public static CmdScriptExpr format<K>(ScriptTemplate pattern, params CmdVar<K>[] args)
            where K : unmanaged
                => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        [MethodImpl(Inline), Op]
        public static ScriptTemplate script(string name, string content)
            => new ScriptTemplate(name, content);


        public static PText template(string pattern, params object[] vars)
            => new PText(pattern, vars);

        public static PT<T0> template<T0>(string pattern, T0 p0)
        {
            var t = new PT<T0>(pattern);
            t.Param0 = p0;
            return t;
        }

        public static PT<T0,T1> template<T0,T1>(string pattern, T0 p0, T1 p1)
        {
            var t = new PT<T0,T1>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            return t;
        }

        public static PT<T0,T1,T2> template<T0,T1,T2>(string pattern, T0 p0, T1 p1, T2 p2)
        {
            var t = new PT<T0,T1,T2>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            return t;
        }

        public static PT<T0,T1,T2,T3> template<T0,T1,T2,T3>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3)
        {
            var t = new PT<T0,T1,T2,T3>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4> template<T0,T1,T2,T3,T4>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            var t = new PT<T0,T1,T2,T3,T4>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5> template<T0,T1,T2,T3,T4,T5>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5,T6> template<T0,T1,T2,T3,T4,T5,T6>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5,T6>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5,T6,T7> template<T0,T1,T2,T3,T4,T5,T6,T7>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5,T6,T7>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            t.Param7 = p7;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5,T6,T7,T8> template<T0,T1,T2,T3,T4,T5,T6,T7,T8>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5,T6,T7,T8>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            t.Param7 = p7;
            t.Param8 = p8;
            return t;
        }
    }
    
}