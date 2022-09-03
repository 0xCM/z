//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEncoder<S,T>
    {
        uint Encode(ReadOnlySpan<S> src, Span<T> dst);
    }

    [Free]
    public interface IDecoder<T,S>
    {
        void Decode(ReadOnlySpan<T> src, Span<S> dst);
    }

    [Free]
    public interface IEncoding<S,T> : IEncoder<S,T>, IDecoder<T,S>
    {

    }
}