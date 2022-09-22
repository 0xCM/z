//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a bit formatter that always produces a bitstring with a fixed length for a given T-value, zero padded as necessary
    /// </summary>
    public class FixedBitFormatter<T> : IFixedBitFormatter<T>
        where T : struct
    {
        readonly BitFormat Config;

        [MethodImpl(Inline)]
        public FixedBitFormatter(uint width)
        {
            Config = BitFormatter.limited(width, (int)width);
        }

        public ref readonly uint Width
        {
            [MethodImpl(Inline)]
            get => ref Config.MaxBitCount;
        }

        uint IFixedBitFormatter.FixedWidth
            => Width;
            
        public string Format(ReadOnlySpan<byte> src)
            => BitRender.format(src, Config);

        [MethodImpl(Inline)]
        public string Format(T src)
            => BitRender.gformat(src, Config);
    }
}