//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBlockSink<W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {

    }

    [Free]
    public interface IBlockSink128<T> : IBlockSink<W128,T>
        where T : unmanaged
    {
        void Deposit(in SpanBlock128<T> src);
    }

    [Free]
    public interface IBlockSink128<H,T> : IBlockSink128<T>
        where T : unmanaged
        where H : IBlockSink128<H,T>
    {

    }

    [Free]
    public interface IBlockSink256<T> : IBlockSink<W256,T>
        where T : unmanaged
    {
        void Deposit(in SpanBlock256<T> src);
    }

    [Free]
    public interface IBlockSink256<H,T> : IBlockSink256<T>
        where T : unmanaged
        where H : IBlockSink256<H,T>
    {

    }

    [Free]
    public interface IBlockSink512<T> : IBlockSink<W512,T>
        where T : unmanaged
    {
        void Deposit(in SpanBlock512<T> src);
    }

    [Free]
    public interface IBlockSink512<H,T> : IBlockSink512<T>
        where T : unmanaged
        where H : IBlockSink512<H,T>
    {

    }

}