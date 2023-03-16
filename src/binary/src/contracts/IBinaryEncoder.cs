//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryEncoder
    {
        uint Encode(object src, uint offset, Span<byte> dst);

        uint Encode(object src, Span<byte> dst)
            => Encode(src,0,dst);
    }    

    public interface IBinaryEncoder<S> : IBinaryEncoder
    {
        uint Encode(S src, uint offset, Span<byte> dst);

        uint Encode(S src, Span<byte> dst)
            => Encode(src,0,dst);
        
        uint IBinaryEncoder.Encode(object src, uint offset, Span<byte> dst)
            => Encode((S)src, offset, dst);
    }
}