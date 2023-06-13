//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsciStringFormatter : IAsciStringFormatter
    {
        [MethodImpl(Inline)]
        public string Format(ReadOnlySpan<AsciSymbol> src)
            => AsciSymbols.format(src);

        [MethodImpl(Inline)]
        public string Format(ReadOnlySpan<byte> src)
            => AsciSymbols.format(src);

        [MethodImpl(Inline)]
        public string Format(ReadOnlySpan<AsciCode> src)
            => AsciSymbols.format(src);
    }
}