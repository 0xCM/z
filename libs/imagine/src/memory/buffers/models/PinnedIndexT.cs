//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe class PinnedIndex<T> : IBufferAllocation, IIndex<T>
        where T : unmanaged
    {
        readonly GCHandle StorageHandle;

        public readonly T[] Storage;

        readonly T* pData;

        public readonly uint Count;

        [MethodImpl(Inline)]
        public PinnedIndex(T[] data)
        {
            StorageHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            pData = (T*)StorageHandle.AddrOfPinnedObject().ToPointer();
            Storage = data;
            Count = (uint)data.Length;
        }

        [MethodImpl(Inline)]
        public Ptr<T> Pointer()
            => new Ptr<T>(pData);

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => pData;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => size<T>() * Count;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)Count;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => cover<T>(pData, Count);
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => cover<T>(pData, Count);
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref seek(pData,0);
        }

        T[] IIndex<T>.Storage
            => Storage;

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(pData, index);
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(pData, index);
        }


        public void Dispose()
        {
            StorageHandle.Free();
        }

        public string Format()
            => (this as IIndex<T>).Format();

        public override string ToString()
            => Format();
    }
}