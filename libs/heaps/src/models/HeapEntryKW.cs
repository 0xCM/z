//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct HeapEntry<K,W>
        where K : unmanaged
        where W : unmanaged
    {
        public readonly K Index;

        public readonly uint Offset;

        public readonly W Length;

        [MethodImpl(Inline)]
        public HeapEntry(K index, uint offset, W length)
        {
            Index = index;
            Offset = offset;
            Length = length;
        }
    }
}