//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBlockRelay128<S,T> : IBlockSource128<S>, IBlockSink128<T>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free]
    public interface IBlockRelay256<S,T> : IBlockSource256<S>, IBlockSink256<T>
        where S : unmanaged
        where T : unmanaged
    {

    }
}