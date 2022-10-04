//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public static TextTemplate template(string pattern, params object[] vars)
            => new TextTemplate(pattern, vars);

        public static TextTemplate<T0> template<T0>(string pattern, T0 p0)
        {
            var t = new TextTemplate<T0>(pattern);
            t.Param0 = p0;
            return t;
        }

        public static TextTemplate<T0,T1> template<T0,T1>(string pattern, T0 p0, T1 p1)
        {
            var t = new TextTemplate<T0,T1>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            return t;
        }

        public static TextTemplate<T0,T1,T2> template<T0,T1,T2>(string pattern, T0 p0, T1 p1, T2 p2)
        {
            var t = new TextTemplate<T0,T1,T2>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3> template<T0,T1,T2,T3>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3)
        {
            var t = new TextTemplate<T0,T1,T2,T3>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4> template<T0,T1,T2,T3,T4>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4,T5> template<T0,T1,T2,T3,T4,T5>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4,T5,T6> template<T0,T1,T2,T3,T4,T5,T6>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5,T6>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7> template<T0,T1,T2,T3,T4,T5,T6,T7>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7>(pattern);
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

        public static TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7,T8> template<T0,T1,T2,T3,T4,T5,T6,T7,T8>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7,T8>(pattern);
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