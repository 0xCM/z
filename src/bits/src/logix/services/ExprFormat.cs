//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExprFormat
    {
        [Op]
        public static string format(UnaryBitLogicKind kind)
            => kind.ToString().ToLower();

        [Op]
        public static string format<T>(UnaryBitLogicKind kind, T arg)
            => $"{kind.Format()}({arg})";

        [Op]
        public static string format(BinaryBitLogicKind kind)
            => kind.ToString().ToLower();

        [Op]
        public static string format<T>(BinaryBitLogicKind kind, T arg1, T arg2)
            => $"{kind.Format()}({arg1}, {arg2})";

        [Op]
        public static string format(ApiComparisonClass kind)
            => kind.ToString().ToLower();

        [Op]
        public static string format(ApiUnaryArithmeticClass kind)
            => kind switch {
                ApiUnaryArithmeticClass.Inc => "++",
                ApiUnaryArithmeticClass.Dec => "--",
                ApiUnaryArithmeticClass.Negate => "-",
                _ => kind.ToString()
            };

        public static string format<T>(ApiUnaryArithmeticClass kind, T arg)
            => $"{kind.Format()}({arg})";

        public static string format<T>(ApiBinaryArithmeticClass kind, T arg1, T arg2)
            => $"{kind.ToString().ToLower()}({arg1}, {arg2})";

        public static string format<T>(ApiComparisonClass kind, T arg1, T arg2)
            => $"{kind.Format()}({arg1}, {arg2})";
    }
}