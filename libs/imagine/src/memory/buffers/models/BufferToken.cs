
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes an allocated buffer
    /// </summary>
    public readonly struct BufferToken : IBufferToken
    {
        public readonly MemoryAddress Address {get;}

        public readonly uint BufferSize {get;}

        [MethodImpl(Inline)]
        public BufferToken(MemoryAddress address, uint size)
        {
            Address = address;
            BufferSize = size;
        }

        /// <summary>
        /// The location of the represented buffer allocation
        /// </summary>
        public IntPtr Handle
            => Address;

        /// <summary>
        /// The size, in bytes, of the represented buffer
        /// </summary>
        public int Size
        {
            [MethodImpl(Inline)]
            get => (int)BufferSize;
        }

        [MethodImpl(Inline)]
        public BufferToken Load(in BinaryCode src)
        {
            memory.load(src, this);
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator Span<byte>(BufferToken src)
            => Algs.edit(src);

        [MethodImpl(Inline)]
        public static implicit operator BufferToken((IntPtr handle, uint size) src)
            => new BufferToken(src.handle, src.size);

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(BufferToken src)
            => src.Handle;
    }
}