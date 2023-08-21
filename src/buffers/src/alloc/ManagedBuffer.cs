//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ManagedBuffer :  IAllocation<byte>
    {
        [Op]
        public static ManagedBuffer alloc(ByteSize size)
            => new (GCHandle.Alloc(new byte[size], GCHandleType.Pinned), size);

        public static ManagedBuffer pin(byte[] src)
            => new (GCHandle.Alloc(src, GCHandleType.Pinned), (uint)src.Length);

        public static ManagedBuffer<T> pin<T>(T[] src)
            where T : unmanaged
                => new (GCHandle.Alloc(src, GCHandleType.Pinned), (uint)src.Length*sys.size<T>());

        public static ManagedBuffer<T> alloc<T>(ulong count)
            where T : unmanaged
                => new (GCHandle.Alloc(new T[count], GCHandleType.Pinned), (uint)count*sys.size<T>());

        public static ManagedBuffer<T> alloc<T>(long count)
            where T : unmanaged
                => alloc<T>((ulong)count);

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

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref  sys.@ref<byte>(BaseAddress);
        }

        public Span<byte> Cells
        {
            [MethodImpl(Inline)]
            get => sys.cover<byte>(BaseAddress, _Size);
        }

        public ByteSize Size
        {
            get => _Size;
        }

        public void Dispose()
        {
            _Handle.Free();
        }
    }
}