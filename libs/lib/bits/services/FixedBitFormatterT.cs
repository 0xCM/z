//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a bit formatter that always produces a bitstring with a fixed length for a given T-value, zero padded as necessary
    /// </summary>
    public readonly struct FixedBitFormatter<T> : IFixedBitFormatter<T>
        where T : struct
    {
        readonly BitFormat Config;

        readonly BitFormatter<T> _Formatter;

        [MethodImpl(Inline)]
        public FixedBitFormatter(byte width)
        {
            Config = BitFormat.limited(width, width);
            _Formatter = new BitFormatter<T>(Config);
        }

        public uint FixedWidth
        {
            [MethodImpl(Inline)]
            get => Config.MaxBitCount;
        }

        public string Format(ReadOnlySpan<byte> src)
            => BitRender.format(src, Config);

        [MethodImpl(Inline)]
        public string Format(T src)
            => BitRender.gformat(src, Config);
    }
}