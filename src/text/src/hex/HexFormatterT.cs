//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexFormatter;

    public readonly struct HexFormatter<T>
        where T : unmanaged
    {
        readonly ISystemFormatter<T> BaseFormatter;

        [MethodImpl(Inline)]
        public HexFormatter(ISystemFormatter<T> formatter)
            => BaseFormatter = formatter;

        public string Format(ReadOnlySpan<T> src, HexFormatOptions options)
            => HexFormatter.format(src, options);

        public string Format(ReadOnlySpan<T> src)
            => HexFormatter.format(src, HexFormatOptions.define(valsep: Chars.Space));
    }
}