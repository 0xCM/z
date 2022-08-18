//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using api = StringBuffers;

    /// <summary>
    /// Defines a character string allocated over a native buffer
    /// </summary>
    public unsafe struct StringBuffer : IBufferAllocation
    {
        [Op]
        public static StringBuffer buffer(ReadOnlySpan<string> src)
        {
            var count = (uint)src.Length;
            var dst = StringBuffers.buffer(api.length(src) + count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(src,i);
                var view = span(s);
                for(var j=0; j<count; j++)
                    dst[counter++] = skip(view,j);
                dst[counter++] = (char)0;
            }
            return dst;
        }

        readonly NativeBuffer<char> Buffer;

        public StringBuffer(uint count)
        {
            Buffer = memory.native<char>(count);
        }

        public StringBuffer(int count)
        {
            Buffer = memory.native<char>((uint)count);
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

        // public StringAllocator StringAllocator()
        //     => new StringAllocator(this);

        // public LabelAllocator LabelAllocator()
        //     => new LabelAllocator(this);

        // public SourceAllocator SourceAllocator()
        //     => new SourceAllocator(this);
    }
}