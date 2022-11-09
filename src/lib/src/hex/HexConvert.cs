//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class HexConvert
    {
        public static bool convert(ReadOnlySpan<char> src, out Seq<HexDigitValue> dst)
        {
            dst = sys.alloc<HexDigitValue>(src.Length);
            return Hex.digits(src, dst.Edit);
        }

        public static bool convert(ReadOnlySpan<AsciCode> src, out Seq<HexDigitValue> dst)
        {
            dst = sys.alloc<HexDigitValue>(src.Length);
            return Hex.digits(src, dst.Edit);
        }

        public static bool convert(ReadOnlySpan<AsciSymbol> src, out Seq<HexDigitValue> dst)
        {
            dst = sys.alloc<HexDigitValue>(src.Length);
            return Hex.digits(src, dst.Edit);
        }
    }
}