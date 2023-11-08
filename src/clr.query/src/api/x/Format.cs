//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        //const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static bool IsDefined(this ApiClassKind src)
            => src != 0;

        [MethodImpl(Inline), Op]
        public static bool IsUserApi(this ApiClassKind src)
            => src.IsDefined() && !src.IsOpaque();

        [Op]
        public static string Format(this ApiClassKind src)
            => src == 0 ? "unclassified" : src.ToString().ToLower();


       [Op]
       public static string Format(this ApiUriScheme src)
            => src.ToString().ToLower();

        [MethodImpl(Inline), Op]
        public static string Format(this SpanKind kind)
            => kind != 0 ? (kind == SpanKind.Mutable ? IDI.Span : IDI.ReadOnlySpan) : EmptyString;

        [MethodImpl(Inline), Op]
        public static string Format(this ApiComparisonClass kind)
            => kind.ToString().ToLower();

        [Op]
        public static string Format(this ApiClassKind? id)
            => id.HasValue ? id.Value.Format() : "unkinded";

        [Op]
        public static string Format(this ApiArithmeticClass key)
            => key switch {
                ApiArithmeticClass.Inc => "++",
                ApiArithmeticClass.Dec => "--",
                ApiArithmeticClass.Negate => "-",
                _ => key.ToString()
            };

        [Op, Closures(Closure)]
        public static string Format<T>(this ApiArithmeticClass key, T a, T b)
            => $"{key.Format()}({a}, {b})";

        [Op]
        public static string Format(this BitShiftClass kind)
            => kind switch {
                BitShiftClass.Sll => "<<",
                BitShiftClass.Srl => ">>",
                BitShiftClass.Rotl => "<<>",
                BitShiftClass.Rotr => ">><",
                _ => kind.ToString()
            };

        [Op]
        public static string Format<S,T>(this BitShiftClass key, S a, T b)
            => $"{a} {key.Format()} {b}";

        [Op]
        public static string Format(this BitLogicClass key)
            => key.ToString().ToLower();

        [Op, Closures(Closure)]
        public static string Format<T>(this BitLogicClass key, T a, T b)
            => string.Format("{0}({1}, {2})", key.Format(), a, b);
    }
}