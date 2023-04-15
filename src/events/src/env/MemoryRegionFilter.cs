//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    internal unsafe struct MemoryRegionFilter : IReceiver<ProcessMemoryRegion>
    {
        readonly Index<ProcessMemoryRegion> Accepted;

        readonly PageProtection Protection;

        uint Position;

        [MethodImpl(Inline)]
        public MemoryRegionFilter(Index<ProcessMemoryRegion> dst, PageProtection protection)
        {
            Accepted = dst;
            Protection = protection;
            Position = 0;
        }

        [MethodImpl(Inline)]
        public void Deposit(in ProcessMemoryRegion src)
        {
            if((src.Protection & Protection) != 0)
                Accepted[Position++] = src;
        }

        public Index<ProcessMemoryRegion> Emit()
            => Accepted;
    }
}