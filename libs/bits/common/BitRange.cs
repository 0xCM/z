//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitRange
    {
        readonly ushort Data;

        [MethodImpl(Inline)]
        public BitRange(ushort src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public BitRange(byte min, byte max)
        {
            Data = bits.join(min,max);
        }

        public byte MinPos
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public byte MaxPos
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 8);
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => (byte)(MaxPos - MinPos + 1);
        }

        public string Format()
            => string.Format("[{0}:{1}]", MaxPos, MinPos);

        public string Format(byte @base)
            => string.Format("[{0}:{1}]", MaxPos + @base, MinPos + @base);

        uint Values<T>(Span<T> dst, byte @base)
            where T : unmanaged
        {
            var minpos = (byte)(MinPos + @base);
            var maxpos = (byte)(MaxPos + @base);
            var minval = minpos == 0 ? 0 : Pow2.pow(minpos);
            var maxval = ((ulong)Pow2.m1(maxpos) << 1) + 1;
            var count = (uint)(maxval - minval + 1);
            var current = minval;
            for(var i=0u; i<count; i++, current++)
                seek(dst,i) = generic<T>(current);
            return count;
        }

        public uint Values<T>(Span<T> dst, bool rebase)
            where T : unmanaged
        {
            if(rebase)
            {
                var width = Width;
                var maxval = Pow2.pow(width);
                var val = 0ul;
                var count = (uint)maxval;
                for(var i=0u; i<count; i++, val++)
                    seek(dst,i) = generic<T>(val);
                return count;
            }
            else
            {
                return Values(dst,0);
            }
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitRange((byte min, byte max) src)
            => new BitRange(src.min,src.max);
    }
}