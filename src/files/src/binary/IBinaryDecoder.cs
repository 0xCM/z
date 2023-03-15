//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryDecoder
    {
        uint Decode(ReadOnlySpan<byte> src, uint offset, out object dst);

        uint Decode(ReadOnlySpan<byte> src, out object dst)
            => Decode(src,0,out dst);
    }    

    public interface IBinaryDecoder<T> : IBinaryDecoder
    {
        uint Decode(ReadOnlySpan<byte> src, uint offset, out T dst);

        uint Decode(ReadOnlySpan<byte> src, out T dst)
            => Decode(src, 0, out dst);
        
        uint IBinaryDecoder.Decode(ReadOnlySpan<byte> src, uint offset, out object dst)
        {
            var consumed = Decode(src, offset, out var _dst);
            dst =_dst;
            return consumed;
        }
    }
}