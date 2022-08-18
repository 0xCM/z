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
            => Asci.format(src);

        [MethodImpl(Inline)]
        public string Format(ReadOnlySpan<byte> src)
            => Asci.format(src);

        [MethodImpl(Inline)]
        public string Format(ReadOnlySpan<AsciCode> src)
            => Asci.format(src);
    }
}