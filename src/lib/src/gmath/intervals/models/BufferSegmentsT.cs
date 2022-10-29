//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a segmented partition over a contiguous buffer
    /// </summary>
    public ref struct BufferSegments<T>
        where T : unmanaged
    {
        readonly Span<T> Buffer;

        public Span<ClosedInterval<uint>> Ranges;

        public uint Dispensed;

        [MethodImpl(Inline)]
        public BufferSegments(Span<T> buffer, uint max)
        {
            Buffer = buffer;
            Ranges = span<ClosedInterval<uint>>(max);
            Dispensed = 0;
        }

        [MethodImpl(Inline)]
        public BufferSegments(Span<T> buffer, Span<ClosedInterval<uint>> ranges)
        {
            Buffer = buffer;
            Ranges = ranges;
            Dispensed = 0;
        }

        public uint MaxSegCount
        {
            [MethodImpl(Inline)]
            get => (uint)Ranges.Length;
        }

        [MethodImpl(Inline)]
        public ref ClosedInterval<uint> Range(byte index)
            => ref seek(Ranges,index);

        [MethodImpl(Inline)]
        public ref ClosedInterval<uint> Range(uint index)
            => ref seek(Ranges,index);

        [MethodImpl(Inline)]
        public void Range(uint index, uint i0, uint i1)
            => Range(index) = (i0,i1);

        public string Format()
        {
            var dst = text.buffer();
            dst.Append("<<");
            for(var i=0u; i<Dispensed; i++)
                dst.Append(Range(i).Format());
            dst.Append(">>");
            return dst.Emit();
        }
    }
}