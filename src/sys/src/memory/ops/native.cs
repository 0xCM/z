//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        /// <summary>
        /// Creates an array of tokens that identify a sequence of buffers
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="size">The number of bytes covered by each buffer</param>
        /// <param name="count">The length of the buffer sequence</param>
        [Op]
        public static BufferToken[] tokenize(IntPtr @base, uint size, uint count)
        {
            var tokens = new BufferToken[count];
            for(var i=0; i<count; i++)
                sys.seek(tokens,i) = (IntPtr.Add(@base, (int)size*i), size);
            return tokens;
        }

        /// <summary>
        /// Creates an array of tokens that identify a sequence of buffers
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="size">The number of bytes covered by each buffer</param>
        /// <param name="count">The length of the buffer sequence</param>
        [Op]
        public static BufferToken[] tokenize(MemoryAddress @base, uint size, uint count)
        {
            var tokens = new BufferToken[count];
            for(var i=0u; i<count; i++)
                sys.seek(tokens,i) = (@base + (size*i), size);
            return tokens;
        }

        /// <summary>
        /// Allocates a native buffer
        /// </summary>
        /// <param name="size">The buffer length in bytes</param>
        [Op]
        public static NativeBuffer native(ByteSize size)
        {
            var buffer = new NativeBuffer((liberate(Marshal.AllocHGlobal((int)size), (int)size), size));
            buffer.Clear();
            return buffer;
        }

        /// <summary>
        /// Allocates a <see cref='NativeBuffer'/> sequence
        /// </summary>
        /// <param name="sizes">The respective buffer sizes</param>
        [Op]
        public static NativeBufferSeq native(ByteSize[] sizes)
        {
            var count = sizes.Length;
            var dst = new NativeBuffer[count];
            for(var i=0; i<count; i++)
                sys.seek(dst,i) = native(sys.skip(sizes,i));
            return new NativeBufferSeq(dst);
        }

        /// <summary>
        /// Allocates a native buffer
        /// </summary>
        /// <param name="size">The buffer length in bytes</param>
        [Op]
        public static NativeBuffer<T> native<T>(uint count)
            where T : unmanaged
        {
            ByteSize sz = count*sys.size<T>();
            var buffer = new NativeBuffer<T>((liberate(Marshal.AllocHGlobal((int)sz), sz), sz));
            buffer.Clear();
            return buffer;
        }

        /// <summary>
        /// Creates a buffer sequence that owns the underlying memory allocation and releases it upon disposal
        /// </summary>
        /// <param name="segsize">The size of each buffer</param>
        /// <param name="segcount">The number of buffers to allocate</param>
        [Op]
        public static NativeBuffers native(ByteSize segsize, byte segcount)
        {
            var allocation = native(segsize*segcount);
            return new NativeBuffers(segsize, segcount, allocation, tokenize(allocation.Handle, segsize, segcount));
        }
    }
}