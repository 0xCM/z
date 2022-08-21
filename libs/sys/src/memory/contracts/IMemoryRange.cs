//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMemoryRange : IAddressable, ISized
    {
        MemoryAddress Min {get;}

        MemoryAddress Max {get;}

        MemoryAddress IAddressable.Address
            => Min;

        ByteSize ISized.ByteCount
            => (ulong)Max - (ulong)Min;

        BitWidth ISized.BitWidth
            => ((ulong)Max - (ulong)Min)*8;
    }

    public interface IMemoryRange<F> : IMemoryRange, IEquatable<F>, IComparable<F>
        where F : unmanaged, IMemoryRange<F>
    {

    }
}