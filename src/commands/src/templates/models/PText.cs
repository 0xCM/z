//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class PText : IPText
    {
        public static CmdScriptExpr format(PScript pattern, params CmdVar[] args)
            => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        public static CmdScriptExpr format<K>(PScript pattern, params CmdVar<K>[] args)
            where K : unmanaged
                => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        [MethodImpl(Inline), Op]
        public static PScript script(string name, string content)
            => new PScript(name, content);

        public static PText define(string pattern, params object[] vars)
            => new PText(pattern, vars);

        public static PT<T0> define<T0>(string pattern, T0 p0)
        {
            var t = new PT<T0>(pattern);
            t.Param0 = p0;
            return t;
        }

        public static PT<T0,T1> define<T0,T1>(string pattern, T0 p0, T1 p1)
        {
            var t = new PT<T0,T1>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            return t;
        }

        public static PT<T0,T1,T2> define<T0,T1,T2>(string pattern, T0 p0, T1 p1, T2 p2)
        {
            var t = new PT<T0,T1,T2>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            return t;
        }

        public static PT<T0,T1,T2,T3> define<T0,T1,T2,T3>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3)
        {
            var t = new PT<T0,T1,T2,T3>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4> define<T0,T1,T2,T3,T4>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            var t = new PT<T0,T1,T2,T3,T4>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            return t;
        }

        public static PT<T0,T1,T2,T3,T4,T5> define<T0,T1,T2,T3,T4,T5>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
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

        public static PT<T0,T1,T2,T3,T4,T5,T6> define<T0,T1,T2,T3,T4,T5,T6>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
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

        public static PT<T0,T1,T2,T3,T4,T5,T6,T7> define<T0,T1,T2,T3,T4,T5,T6,T7>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
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

        public static PT<T0,T1,T2,T3,T4,T5,T6,T7,T8> define<T0,T1,T2,T3,T4,T5,T6,T7,T8>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
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

        public readonly TextBlock Pattern;

        public readonly Seq<object> Vars;

        public readonly uint VarCount;

        public PText(string src)
        {
            Pattern = src ?? EmptyString;
            Vars = sys.empty<object>();
            VarCount = 0;
        }

        public PText(string src, object[] vars)
        {
            Pattern = src ?? EmptyString;
            Vars = vars;
            VarCount = (uint)vars.Length;
        }

        public PText(string src, uint varcount)
        {
            Pattern = src ?? EmptyString;
            Vars = sys.alloc<object>(varcount);
            VarCount = varcount;
            for(var i=0; i<VarCount; i++)
                this[i] = EmptyString;
        }

        [MethodImpl(Inline)]
        public ref T Var<T>(uint index)
            => ref sys.@as<object,T>(Vars[index]);

        [MethodImpl(Inline)]
        public ref T Var<T>(int index)
            => ref sys.@as<object,T>(Vars[index]);

        public ref object this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Vars[i];
        }

        public ref object this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Vars[i];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsNonEmpty;
        }

        Seq<object> IPText.Vars
            => Vars;

        TextBlock IPText.Pattern
            => Pattern;

        public string Format()
            => Vars.IsNonEmpty ? string.Format(Pattern, Vars) : Pattern;

        public override string ToString()
            => Format();
    }
}