//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static bool map(ReadOnlySpan<char> src, Span<HexDigitValue> dst)
            => digits(src, dst);

        [MethodImpl(Inline), Op]
        public static bool map(HexString src, Span<HexDigitValue> dst)
            => digits(src.Data, dst);
    }
}