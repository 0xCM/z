//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = StringBuffers;

    /// <summary>
    /// Defines a string over S-symbols allocated over a native buffer
    /// </summary>
    public unsafe struct StringBuffer<S> : IBufferAllocation
        where S : unmanaged
    {
        readonly NativeBuffer<S> Buffer;

        internal StringBuffer(uint count)
        {
            Buffer = memory.native<S>(count);
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        /// <summary>
        /// The maximum number of symbols in the string
        /// </summary>
        public uint Length
        {
            [MethodImpl(Inline)]
            get => Buffer.Count;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<S>();
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Buffer.Width;
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(ulong index)
            => Buffer.BaseAddress + index*size<S>();

        [MethodImpl(Inline)]
        public MemoryAddress Address(long index)
            => Address((ulong)index);

        [MethodImpl(Inline)]
        public ref S Symbol(ulong index)
            => ref seek(Buffer.Edit,index);

        [MethodImpl(Inline)]
        public ref S Symbol(long index)
            => ref seek(Buffer.Edit,index);

        public ref S this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public ref S this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        [MethodImpl(Inline)]
        public bool Store(ReadOnlySpan<S> src, uint offset)
            => api.store(src, offset, this);
    }
}