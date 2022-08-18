//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class BitfieldSeg<S,T>
        where S : unmanaged
        where T : unmanaged
    {

        [MethodImpl(Inline)]
        public static X extract<X>(X src, byte min, byte max)
            where X : unmanaged
        {
            if(width<X>() == 8)
                return @as<byte,X>(bits.extract(bw8(src), min, max));
            else if(width<X>() == 16)
                return @as<ushort,X>(bits.extract(bw16(src), min, max));
            else if(width<X>() == 32)
                return @as<uint,X>(bits.extract(bw32(src), min, max));
            else
                return @as<ulong,X>(bits.extract(bw64(src), min, max));
        }

        protected ClosedInterval<byte> SegRange {get;}

        public S Mask {get;}

        public byte MinPos
        {
            [MethodImpl(Inline)]
            get => SegRange.Min;
        }

        public byte MaxPos
        {
            [MethodImpl(Inline)]
            get => SegRange.Max;
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => (byte)(MaxPos - MinPos + 1);
        }

        S SourceValue;

        public T Value
        {
            [MethodImpl(Inline)]
            get => @as<S,T>(extract(SourceValue, SegRange.Min, SegRange.Max));

            [MethodImpl(Inline)]
            set => SourceValue = Bitfields.or(Bitfields.scatter(@as<T,S>(value), Mask), Bitfields.and(SourceValue, Bitfields.not(Mask)));
        }

        public BitfieldSeg(S mask, ClosedInterval<byte> seg)
        {
            Mask = mask;
            SegRange = seg;
        }

        [MethodImpl(Inline)]
        public S Source()
            => SourceValue;

        [MethodImpl(Inline)]
        public void Source(S src)
            => SourceValue = src;

        [MethodImpl(Inline)]
        public byte Render(Span<char> dst)
            => (byte)BitRender.render(bytes(Value), Width, dst);

        [MethodImpl(Inline)]
        public byte Render(uint offset, Span<char> dst)
            => (byte)BitRender.render(bytes(Value), Width, slice(dst,offset));
    }
}