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

        public static TernaryBitLogicKind Next(this TernaryBitLogicKind src)
            => src != TernaryBitLogicKind.XFF
                ? (TernaryBitLogicKind)((uint)(src) + 1u)
                : TernaryBitLogicKind.X00;

        public static string Format(this TernaryBitLogicKind kind)
            => kind.ToString();

        public static string Format<T>(this TernaryBitLogicKind kind, T arg1, T arg2, T arg3)
            => $"{kind.Format()}({arg1}, {arg2}, {arg3})";

        public static string Format(this Type src)
            => src.Name.Replace("`1", EmptyString).Replace("`2", EmptyString);

        public static string Format(this MethodInfo src)
            => src.ToString().Replace("`1", EmptyString).Replace("`2", EmptyString);

        public static string Format(this Assembly src)
            => src.GetSimpleName();

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