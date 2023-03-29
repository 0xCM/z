//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = TrimmedBlocks;
    using static sys;
    public class TrimmedBlocks
    {
        [MethodImpl(Inline)]
        public static TrimmedBlock<T> trim<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src;
        
        public static string format<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var sz = size(src);
            if(sz == 0)
                sz = 1;
            return sys.slice(src.BlockData, 0, sz).FormatHex();
        }

        [MethodImpl(Inline)]
        public static ByteSize size<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var data = src.BlockData;
            var length = (int)src.BlockSize;
            var size = 0;
            for(var i=length-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(b == 0)
                    continue;
                else
                {
                    size = i + 1;
                    break;
                }

            }
            return size;
        }
    }
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