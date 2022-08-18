
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a native buffer allocation
    /// </summary>
    [ApiHost]
    public readonly struct NativeBuffer : IBufferAllocation
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Zero-fills a token-identified buffer and returns the cleared memory content
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Span<byte> clear(in NativeBuffers src, byte index)
            => sys.clear(span(src.Token(index)));

        [MethodImpl(Inline), Op]
        public static void clear(BufferToken src)
            => span(src).Clear();

        /// <summary>
        /// Covers a token-identified buffer with a bytespan
        /// </summary>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> span(BufferToken src)
            => Algs.cover(src.Address.Pointer<byte>(), src.BufferSize);

        /// <summary>
        /// Covers a token-identified buffer with a span
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> span<T>(BufferToken src)
            where T : unmanaged
                => Algs.cover(src.Address.Pointer<byte>(), src.BufferSize).Recover<T>();

        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> span(NativeBuffer src)
            => new Span<byte>(src.Handle.ToPointer(), (int)src.Size);

        [MethodImpl(Inline), Op]
        public static unsafe Span<T> span<T>(in NativeBuffer<T> src)
            where T : unmanaged
                => new Span<T>(src.Handle.ToPointer(), (int)src.Count);

        /// <summary>
        /// Deallocates a native allocation
        /// </summary>
        /// <param name="handle">The allocation handle</param>
        [MethodImpl(Inline), Op]
        public static void release(in NativeBuffer src)
            => Marshal.FreeHGlobal(src.Handle);

        /// <summary>
        /// Deallocates a native allocation
        /// </summary>
        /// <param name="handle">The allocation handle</param>
        [MethodImpl(Inline), Op]
        public static void release<T>(in NativeBuffer<T> src)
            where T : unmanaged
                => Marshal.FreeHGlobal(src.Handle);

        /// <summary>
        /// Identifies a buffer of specified base address and size
        /// </summary>
        /// <param name="base"></param>
        /// <param name="size"></param>
        [MethodImpl(Inline), Op]
        public static BufferToken token(MemoryAddress @base, ByteSize size)
            => new BufferToken(@base,size);

        public IntPtr Handle {get;}

        public ByteSize Size {get;}

        [MethodImpl(Inline)]
        internal NativeBuffer(BufferToken token)
        {
            Handle = token.Handle;
            Size = (uint)token.Size;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Handle;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        [MethodImpl(Inline)]
        public void Clear()
            => Edit.Clear();

        public bool IsAllocated
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        /// <summary>
        /// Presents the allocation via a span
        /// </summary>
        public unsafe Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => span(this);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => span(this);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint offset)
            => BaseAddress + offset;


        [MethodImpl(Inline)]
        public void Dispose()
            => release(this);

        [MethodImpl(Inline)]
        public static implicit operator BufferToken(NativeBuffer src)
            => token(src.BaseAddress, src.Size);

        [MethodImpl(Inline)]
        public static implicit operator Span<byte>(NativeBuffer src)
            => src.Edit;

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(NativeBuffer src)
            => src.Handle;

        [MethodImpl(Inline)]
        public static unsafe implicit operator byte*(NativeBuffer src)
            => src.BaseAddress.Pointer<byte>();

        public static NativeBuffer Empty => default;
    }
}