//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = StringBuffers;

    /// <summary>
    /// Defines a character string allocated over a native buffer
    /// </summary>
    public unsafe struct StringBuffer : IBufferAllocation
    {
        readonly NativeBuffer<char> Buffer;

        internal StringBuffer(uint count)
        {
            Buffer = memory.native<char>(count);
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
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
            get => Length*size<char>();
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(ulong index)
            => Buffer.BaseAddress + index*2;

        [MethodImpl(Inline)]
        public MemoryAddress Address(long index)
            => Address((ulong)index);

        [MethodImpl(Inline)]
        public ref char Symbol(ulong index)
            => ref seek(Buffer.Edit,index);

        [MethodImpl(Inline)]
        public ref char Symbol(long index)
            => ref seek(Buffer.Edit,index);

        public ref char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public ref char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        [MethodImpl(Inline)]
        public bool Store(ReadOnlySpan<char> src, uint offset)
            => api.store(src, offset, this);

        [MethodImpl(Inline)]
        public Label StoreLabel(ReadOnlySpan<char> src, uint offset)
            => api.label(src, offset, this);

        [MethodImpl(Inline)]
        public StringRef StoreString(ReadOnlySpan<char> src, uint offset)
            => api.stringref(src, offset, this);

        public Span<char> Edit
        {
            [MethodImpl(Inline)]
            get => Buffer.Edit;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Buffer.View;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Buffer.Width;
        }
    }
}