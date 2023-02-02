//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISpanBlockProjector<W,S,T>
        where W : unmanaged, ITypeWidth
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free]
    public interface ISpanBlockProjector128<S,T> : ISpanBlockProjector<W128,S,T>
        where S : unmanaged
        where T : unmanaged
    {
        uint Map(SpanBlock128<S> src, SpanBlock128<T> dst);
    }

    [Free]
    public interface ISpanBlockProjector256<S,T> : ISpanBlockProjector<W256,S,T>
        where S : unmanaged
        where T : unmanaged
    {
        uint Map(SpanBlock256<S> src, SpanBlock256<T> dst);
    }
}