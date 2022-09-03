//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [MethodImpl(Inline), Op]
        public static string format(ReadOnlySpan<char> src)
            => new string(src);

        [Op]
        public static string format(string pattern, ReadOnlySpan<char> a0)
            => string.Format(pattern, format(a0));

        [Op]
        public static string format(string pattern, ReadOnlySpan<char> a0, ReadOnlySpan<char> a1)
            => string.Format(pattern, format(a0), format(a1));

        [Op]
        public static string format(string pattern, ReadOnlySpan<char> a0, ReadOnlySpan<char> a1, ReadOnlySpan<char> a2)
            => string.Format(pattern, format(a0), format(a1), format(a2));

        [Op]
        public static string format(string pattern, params object[] args)
            => string.Format(pattern, args);

        [Op]
        public static string format(object src)
            => src is null ? "<null>" : src.ToString();

        public static string format<T>(string pattern, T a)
            => string.Format(pattern, a is ITextual t ? t.Format() : $"{a}");

        public static string format<A,B>(string pattern, A a, B b)
            => string.Format(pattern,
                a is ITextual t0 ? t0.Format() : $"{a}",
                b is ITextual t1 ? t1.Format() : $"{b}"
                );

        public static string format<A,B,C>(string pattern, A a, B b, C c)
            => string.Format(pattern,
                            a is ITextual t0 ? t0.Format() : $"{a}",
                            b is ITextual t1 ? t1.Format() : $"{b}",
                            c is ITextual t2 ? t2.Format() : $"{c}"
                            );

        public static string format<A,B,C,D>(string pattern, A a, B b, C c, D d)
            => string.Format(pattern,
                            a is ITextual t0 ? t0.Format() : $"{a}",
                            b is ITextual t1 ? t1.Format() : $"{b}",
                            c is ITextual t2 ? t2.Format() : $"{c}",
                            d is ITextual t3 ? t3.Format() : $"{d}"
                            );

        public static string format<A,B,C,D,E>(string pattern, A a, B b, C c, D d, E e)
            => string.Format(pattern,
                            a is ITextual t0 ? t0.Format() : $"{a}",
                            b is ITextual t1 ? t1.Format() : $"{b}",
                            c is ITextual t2 ? t2.Format() : $"{c}",
                            d is ITextual t3 ? t3.Format() : $"{d}",
                            e is ITextual t4 ? t4.Format() : $"{e}"
                            );

        public static string format<A,B>(A a, B b)
            => string.Format(PSx2, a, b);

        public static string format<A,B,C>(A a, B b, C c)
            where A : ITextual
            where B : ITextual
            where C : ITextual
                => string.Format(PSx3, a.Format(), b.Format(), c.Format());

        public static string format<A,B,C,D>(A a, B b, C c, D d)
            where A : ITextual
            where B : ITextual
            where C : ITextual
            where D : ITextual
                => string.Format(PSx4, a.Format(), b.Format(), c.Format(), d.Format());
    }
}