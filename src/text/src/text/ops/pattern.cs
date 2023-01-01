//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static TextPatterns;

    partial class text
    {
        public static PT<T0> pattern<T0>(string spec, T0 p0)
        {
            var t = new PT<T0>(spec);
            t.Param0 = p0;
            return t;
        }

        public static PT<T0,T1> pattern<T0,T1>(string spec, T0 p0, T1 p1)
        {
            var t = new PT<T0,T1>(spec);
            t.Param0 = p0;
            t.Param1 = p1;
            return t;
        }

        public static PT<T0,T1,T2> pattern<T0,T1,T2>(string spec, T0 p0, T1 p1, T2 p2)
        {
            var t = new PT<T0,T1,T2>(spec);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            return t;
        }

        public static PT<T0,T1,T2,T3> pattern<T0,T1,T2,T3>(string spec, T0 p0, T1 p1, T2 p2, T3 p3)
        {
            var t = new PT<T0,T1,T2,T3>(spec);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4> pattern<T0,T1,T2,T3,T4>(string spec, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            var t = new PT<T0,T1,T2,T3,T4>(spec);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5> pattern<T0,T1,T2,T3,T4,T5>(string spec, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5>(spec);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5,T6> pattern<T0,T1,T2,T3,T4,T5,T6>(string spec, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5,T6>(spec);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5,T6,T7> pattern<T0,T1,T2,T3,T4,T5,T6,T7>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
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

        public static PT<T0,T1,T2,T3,T4,T5,T6,T7,T8> pattern<T0,T1,T2,T3,T4,T5,T6,T7,T8>(string spec, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        {
            var t = new PT<T0,T1,T2,T3,T4,T5,T6,T7,T8>(spec);
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