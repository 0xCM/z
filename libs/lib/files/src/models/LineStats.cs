//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    [StructLayout(StructLayout,Size=8)]
    public struct LineStats
    {
        enum BfSpec : byte
        {
            [Render(12)]
            LineNumber = 19,

            [Render(12)]
            Offset = 25,

            [Render(1)]
            Length = 8,
        }

        const string RenderPattern = "{0,-12} | {1,-12} | {2,-1}";

        public static string Header
            => string.Format(RenderPattern, BfSpec.LineNumber, BfSpec.Offset, BfSpec.Length);

        [MethodImpl(Inline)]
        public LineStats(uint number, uint offset, byte length)
            => this = define(number,offset,length);

        public LineNumber LineNumber
        {
            [MethodImpl(Inline)]
            get
            {
                split(this, out var dst, out _, out _);
                return dst;
            }
        }

        public uint Offset
        {
            [MethodImpl(Inline)]
            get
            {
                split(this, out _, out var dst, out _);
                return dst;
            }
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get
            {
                split(this, out _, out _, out var dst);
                return dst;
            }
        }

        public string Format()
            => string.Format(RenderPattern, LineNumber, Offset, Length);

        public override string ToString()
            => Format();

        public static implicit operator ulong(LineStats src)
            => @as<LineStats,ulong>(src);

        public static implicit operator LineStats(ulong src)
            => @as<ulong,LineStats>(src);

        public static LineStats Empty => default;

        const byte NumberWidth = (byte)BfSpec.LineNumber;

        const byte OffsetWidth = (byte)BfSpec.Offset;

        const byte NumberOffset = 0;

        const byte OffsetOffset = NumberWidth;

        const byte LengthOffset = NumberWidth + OffsetWidth;

        const uint Max19u = 524287;

        const uint Max25u = 33554431;

        const ulong OffsetMask = Max25u;

        const ulong NumberMask = Max19u;

        const ulong LengthMask = byte.MaxValue;

        [MethodImpl(Inline)]
        static LineStats define(uint number, uint offset, byte length)
        {
            var dst = 0ul;
            dst |= ((ulong)number & NumberMask);
            dst |= (((ulong)offset & OffsetMask) << OffsetOffset);
            dst |= ((ulong)(length & LengthMask) << LengthOffset);
            return @as<ulong,LineStats>(dst);
        }

        static void split(LineStats stats, out uint number, out uint offset, out byte length)
        {
            var src = @as<LineStats,ulong>(stats);
            number = (uint)((src >> NumberOffset) & NumberMask);
            offset = (uint)((src >> OffsetOffset) & OffsetMask);
            length = (byte)((src >> LengthOffset) & LengthMask);
        }
    }
}