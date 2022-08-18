//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using ULK = UnaryBitLogicKind;
    using BLK = BinaryBitLogicKind;
    using TLK = TernaryBitLogicKind;

    [ApiHost]
    public readonly struct LogicSig
    {
        public static string sig(ULK kind)
            => string.Concat(format(kind), Chars.Colon, "bit");

        public static string sig(BLK kind)
            => string.Concat(format(kind), Chars.Colon, "bit");

        public static string sig(TLK kind)
            => string.Concat(format(kind), Chars.Colon, "bit");

        public static string sig<T>(ULK kind)
             where T : unmanaged
                => string.Concat(format(kind), Chars.Colon, NumericKinds.keyword<T>());

        public static string sig<T>(BLK kind)
            where T : unmanaged
                => string.Concat(format(kind), Chars.Colon, NumericKinds.keyword<T>());

        public static string sig<T>(TLK kind)
            where T : unmanaged
                => string.Concat(format(kind), Chars.Colon, NumericKinds.keyword<T>());

        public static string sig<T>(BitShiftClass kind)
            where T : unmanaged
                => $"{kind}:{typeof(T).NumericKind().Keyword()}";

        public static string sig<T>(ApiComparisonClass kind)
            where T : unmanaged
                => $"{kind}:{typeof(T).NumericKind().Keyword()}";

        public static string sig<T>(ApiUnaryArithmeticClass kind)
            where T : unmanaged
                => $"{kind}:{typeof(T).NumericKind().Keyword()}";

        public static string sig<T>(ApiBinaryArithmeticClass kind)
            where T : unmanaged
                => $"{kind}:{typeof(T).NumericKind().Keyword()}";

        public static string format(ULK kind)
            => kind.ToString().ToLower();

        public static string format(TLK kind)
            => kind.ToString().ToLower();

        public static string format(BLK kind)
            => kind.ToString().ToLower();

        public static string format(BitLogicClass kind)
            => kind.Format();
    }
}