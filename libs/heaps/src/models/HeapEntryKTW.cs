//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a key to access a symbol deposited in a <see cref='SymHeap{K,T,W}'/>
    /// </summary>
    /// <typeparam name="K">The index type</typeparam>
    /// <typeparam name="T">The offset type</typeparam>
    /// <typeparam name="W">The length type</typeparam>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct HeapEntry<K,T,W>
        where K : unmanaged
        where T : unmanaged
        where W : unmanaged
    {
        public readonly K Index;

        public readonly T Offset;

        public readonly W Length;

        [MethodImpl(Inline)]
        public HeapEntry(K index, T offset, W length)
        {
            Index = index;
            Offset = offset;
            Length = length;
        }
    }
}