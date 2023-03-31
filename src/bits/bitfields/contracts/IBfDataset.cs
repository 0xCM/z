//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBfDataset
    {
        asci64 Name {get;}

        DataSize Size {get;}

        uint FieldCount {get;}

        string BitstringPattern {get;}

        ref readonly Index<uint> Offsets {get;}

        ref readonly Index<byte> Widths {get;}

        ref readonly BfIntervals Intervals {get;}

        ref readonly Index<BitMask> Masks {get;}

        ref readonly byte Width(int index)
            => ref Widths[index];

        ref readonly byte Width(uint index)
            => ref Widths[index];

        ref readonly uint Offset(int index)
            => ref Offsets[index];
        ref readonly uint Offset(uint index)
            => ref Offsets[index];

        ref readonly BitMask Mask(int index)
            => ref Masks[index];

        ref readonly BitMask Mask(uint index)
            => ref Masks[index];

        ref readonly BfInterval Interval(int index)
            => ref Intervals[index];

        ref readonly BfInterval Interval(uint index)
            => ref Intervals[index];
    }

    public interface IBfDataset<F> : IBfDataset
        where F : unmanaged, Enum
    {
        ref readonly Index<F> Fields {get;}

        uint Index(F field);

        new ref readonly BfIntervals<F> Intervals {get;}

        ref readonly BfInterval<F> Interval(F field);
    }
}