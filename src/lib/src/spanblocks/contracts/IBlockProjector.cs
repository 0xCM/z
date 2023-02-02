//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBlockProjector<W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {

    }

    [Free]
    public interface IBlockProjector128<S,T> : IBlockProjector<W128,T>
        where S : unmanaged
        where T : unmanaged
    {
        void Project(SpanBlock128<S> src, SpanBlock128<T> dst);
    }

    [Free]
    public interface IBlockProjector128<P,S,T> : IBlockProjector128<S,T>
        where P : IBlockProjector128<P,S,T>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free]
    public interface IBlockProjector256<S,T> : IBlockProjector<W256,T>
        where S : unmanaged
        where T : unmanaged
    {
         void Project(SpanBlock256<S> src, SpanBlock256<T> dst);
    }

    [Free]
    public interface IBlockProjector256<P,S,T> : IBlockProjector256<S,T>
        where P : IBlockProjector256<P,S,T>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free]
    public interface IBlockProjector512<S,T> : IBlockProjector<W512,T>
        where S : unmanaged
        where T : unmanaged
    {
        void Project(in SpanBlock512<S> src, in SpanBlock512<T> dst);
    }

    [Free]
    public interface IBlockProjector512<P,S,T> : IBlockProjector512<S,T>
        where P : IBlockProjector512<P,S,T>
        where S : unmanaged
        where T : unmanaged
    {

    }
}