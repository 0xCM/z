//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Storage;

    public readonly struct TrimmedBlock<T>
        where T : unmanaged, IStorageBlock<T>
    {
        public readonly T Block;

        [MethodImpl(Inline)]
        public TrimmedBlock(T data)
        {
            Block = data;
        }

        public ByteSize BlockSize
        {
            [MethodImpl(Inline)]
            get => Block.ByteCount;
        }

        public ByteSize TrimmedSize
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public ReadOnlySpan<byte> BlockData
        {
            [MethodImpl(Inline)]
            get => Block.Bytes;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TrimmedBlock<T>(T src)
            => new TrimmedBlock<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(TrimmedBlock<T> src)
            => src.Block;
    }
}