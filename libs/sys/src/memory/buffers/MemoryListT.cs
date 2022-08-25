//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a list of <typeparamref name='T'/> over an unmanaged buffer
    /// </summary>
    public unsafe readonly struct MemoryList<T> : IDisposable
        where T : unmanaged
    {
        readonly NativeBuffer Buffer;

        MemoryAddress Base
        {
            [MethodImpl(Inline)]
             get => Buffer.BaseAddress;
        }

        [MethodImpl(Inline)]
        internal MemoryList(NativeBuffer buffer)
        {
            Buffer = buffer;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Buffer.Size;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref @ref(Base.Pointer<T>());
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => sys.cover(Base.Pointer<byte>(), Size);
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}