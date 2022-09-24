//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Configurable bit data type formatter
    /// </summary>
    public readonly struct BitFormatter<T> : IBitFormatter<T>
        where T : struct
    {
        readonly BitFormat Config;

        [MethodImpl(Inline)]
        public BitFormatter(BitFormat config)
            => Config = config;

        public string Format(ReadOnlySpan<byte> src)
            => BitRender.format(src, Config);

        [MethodImpl(Inline)]
        public string Format(T src)
            => BitRender.gformat(src, Config);
    }
}