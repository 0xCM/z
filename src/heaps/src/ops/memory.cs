//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        [MethodImpl(Inline), Op]
        public static MemoryHeap memory(MemoryAddress @base, Span<byte> data, Span<Address32> offsets)
            => new MemoryHeap(@base, data,offsets);
    }
}