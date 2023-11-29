//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a partition over an interval
    /// </summary>
    public readonly ref struct Partition<T>
    {
        readonly Span<T> Data;

        readonly ReadOnlySpan<uint> Offsets;

        [MethodImpl(Inline)]
        public Partition(Span<T> src, ReadOnlySpan<uint> offsets)
        {
            Data = src;
            Offsets = offsets;
        }

        [MethodImpl(Inline)]
        public Span<T> Segment(uint index)
        {
            ref readonly var i0 = ref skip(Offsets,index);
            if(index < Offsets.Length - 2)
            {
                ref readonly var i1 = ref skip(Offsets, index + 1);
                return slice(Data, i0, i1 - i0);
            }
            else
            {
                return slice(Data,i0);
            }
        }

        public Span<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Segment(index);
        }
    }
}