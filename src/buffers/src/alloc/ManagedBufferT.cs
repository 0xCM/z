//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ManagedBuffer<T> : IAllocation<T>
        where T : unmanaged
    {
        readonly GCHandle _Handle;

        readonly uint _Size;

        [MethodImpl(Inline)]
        public ManagedBuffer(GCHandle handle, uint size)
        {
            _Handle = handle;
            _Size = size;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => _Handle.AddrOfPinnedObject();
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<T>(BaseAddress, _Size);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public void Dispose()
        {
            _Handle.Free();
        }
    }
}