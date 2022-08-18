//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBlockSource<W,S>
        where W : unmanaged, ITypeWidth
        where S : unmanaged
    {
        uint BlockCount {get;}
    }

    [Free]
    public interface IBlockSource128<S> : IBlockSource<W128,S>
        where S : unmanaged
    {
        SpanBlock128<S> Emit(uint index);
    }

    [Free]
    public interface IBlockSource128<H,S> : IBlockSource128<S>
        where H : IBlockSource128<H,S>
        where S : unmanaged
    {

    }

    [Free]
    public interface IBlockSource256<S> : IBlockSource<W256,S>
        where S : unmanaged
    {
        SpanBlock256<S> Emit(uint index);
    }

    [Free]
    public interface IBlockSource256<H,S> : IBlockSource256<S>
        where H : IBlockSource256<H,S>
        where S : unmanaged
    {

    }

    [Free]
    public interface IBlockSource512<S> : IBlockSource<W512,S>
        where S : unmanaged
    {
        SpanBlock512<S> Emit(uint index);
    }

    [Free]
    public interface IBlockSource512<H,S> : IBlockSource512<S>
        where H : IBlockSource512<H,S>
        where S : unmanaged
    {

    }
}