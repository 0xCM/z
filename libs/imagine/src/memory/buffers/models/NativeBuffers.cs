//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Covers a sequence of allocated buffers
    /// </summary>
    public unsafe class NativeBuffers : IDisposable
    {
        readonly NativeBuffer Allocation;

        readonly Index<BufferToken> Tokens;

        readonly ByteSize SegSize;

        readonly byte SegCount;

        readonly uint TotalSize;

        internal NativeBuffers(ByteSize segsize, byte segcount, NativeBuffer allocation, Index<BufferToken> tokens)
        {
            SegCount = segcount;
            SegSize = segsize;
            TotalSize = SegCount*SegSize;
            Allocation = allocation;
            Tokens = tokens;
        }

        [MethodImpl(Inline)]
        public Span<byte> Edit(byte index)
            => NativeBuffer.span(Token(index));

        /// <summary>
        /// Covers a token-identified buffer with a span over cells of unmanaged type
        /// </summary>
        /// <param name="index">The buffer index</param>
        [MethodImpl(Inline)]
        public Span<T> Buffer<T>(byte index)
            where T : unmanaged
                => Edit(index).Recover<T>();

        /// <summary>
        /// Retrieves an index-identified token
        /// </summary>
        /// <param name="index">The buffer index</param>
        [MethodImpl(Inline)]
        public ref readonly BufferToken Token(byte index)
            => ref Tokens[index];

        /// <summary>
        /// Retrieves an index-identified token
        /// </summary>
        /// <param name="index">The buffer index</param>
        public ref readonly BufferToken this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Token(index);
        }

        /// <summary>
        /// Retrieves a token identified by sequence id
        /// </summary>
        /// <param name="index">The buffer index</param>
        public ref readonly BufferToken this[BufferSeqId id]
        {
            [MethodImpl(Inline)]
            get => ref Token((byte)id);
        }

        [MethodImpl(Inline)]
        public BufferTokens Tokenize()
            => Tokens.Storage;

        public void Dispose()
        {
            Allocation.Dispose();
        }
    }
}