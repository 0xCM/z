//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XExprFormat
    {
        [MethodImpl(Inline)]
        public static string Format(this UnaryBitLogicKind kind)
            => ExprFormat.format(kind);

        [MethodImpl(Inline)]
        public static string Format<T>(this UnaryBitLogicKind kind, T arg)
            => ExprFormat.format(kind,arg);

        [MethodImpl(Inline)]
        public static string Format(this ApiUnaryArithmeticClass kind)
            => ExprFormat.format(kind);

        [MethodImpl(Inline)]
        public static string Format<T>(this ApiUnaryArithmeticClass kind, T arg)
            => ExprFormat.format(kind, arg);

        [MethodImpl(Inline)]
        public static string Format(this BinaryBitLogicKind kind)
            => kind.ToString().ToLower();

        [MethodImpl(Inline)]
        public static string Format<T>(this BinaryBitLogicKind kind, T arg1, T arg2)
            => ExprFormat.format(kind, arg1, arg2);

        [MethodImpl(Inline)]
        public static string Format<T>(this ApiBinaryArithmeticClass kind, T arg1, T arg2)
            => ExprFormat.format(kind, arg1, arg2);

        [MethodImpl(Inline)]
        public static string Format<T>(this ApiComparisonClass kind, T arg1, T arg2)
            => ExprFormat.format(kind, arg1, arg2);
    }
}