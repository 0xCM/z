//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public unsafe interface INativeSeq : ISeq
    {
        MemoryAddress BaseAddress {get;}

        uint Size {get;}

        uint CellSize {get;}

        uint CellCount {get;}

        byte* Pointer()
            => BaseAddress.Pointer<byte>();
    }

    [Free]
    public unsafe interface INativeSeq<T> : INativeSeq, ISeq<T>
        where T : unmanaged
    {
        uint INativeSeq.CellSize
            => Sized.size<T>();

        uint INativeSeq.CellCount
            => Size/CellSize;

        unsafe new T* Pointer()
            => BaseAddress.Pointer<T>();
    }
}