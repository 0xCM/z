//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ManagedBuffer<T> :  Allocation<T>
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

        public override MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => _Handle.AddrOfPinnedObject();
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref @ref<T>(BaseAddress);
        }

        protected override Span<T> Data
        {
            [MethodImpl(Inline)]
            get => cover<T>(BaseAddress, _Size);
        }

        public override ByteSize Size
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => _Size;
        }


        protected override void Dispose()
        {
            _Handle.Free();
        }
    }
}