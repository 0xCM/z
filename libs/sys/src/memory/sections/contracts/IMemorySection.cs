//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MemorySections;

    [Free]
    public interface IMemorySection
    {
        ushort Index { get; }

        MemoryAddress Base();

        Capacity Capacity();

        Span<byte> Storage();

        Span<T> Storage<T>()
            where T : unmanaged
                => sys.recover<T>(Storage());

        Descriptor Descriptor()
            => new Descriptor(Index, Base(), Capacity());

        ByteSize SegSize
            => Capacity().SegSize;

        byte SegScale
            => Capacity().SegsPerBlock;

        uint BlockCount
            => Capacity().BlockCount;

        ByteSize BlockSize
            => Capacity().BlockSize;

        ByteSize TotalSize
            => Capacity().TotalSize;
    }

    [Free]
    public interface IMemorySection<T> : IMemorySection
        where T : unmanaged, IMemorySection<T>
    {
    }
}