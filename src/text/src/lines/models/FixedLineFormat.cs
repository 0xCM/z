//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FixedLineFormat
    {
        Index<FixedLineSegment> Data {get;}

        [MethodImpl(Inline)]
        public FixedLineFormat(FixedLineSegment[] segments)
        {
            Data = segments;
        }

        public ReadOnlySpan<FixedLineSegment> Segments
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ushort TotalLength
        {
            [MethodImpl(Inline)]
            get => FixedLines.length(this);
        }
    }
}