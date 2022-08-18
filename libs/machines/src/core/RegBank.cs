//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RegBank : IDisposable
    {
        public readonly RegFile File;

        readonly NativeBuffer Buffer;

        readonly Index<RegAlloc> Allocated;

        internal RegBank(RegFile file, NativeBuffer buffer, RegAlloc[] allocs)
        {
            File = file;
            Buffer = buffer;
            Allocated = allocs;
        }

        [MethodImpl(Inline)]
        public ref RegAlloc Allocation(uint seq)
            => ref Allocated[seq];

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public ref RegAlloc this[uint seq]
        {
            [MethodImpl(Inline)]
            get => ref Allocation(seq);
        }

        public Span<RegAlloc> Allocations
        {
            [MethodImpl(Inline)]
            get => Allocated.Edit;
        }
    }
}