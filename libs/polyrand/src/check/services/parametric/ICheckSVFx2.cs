//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICheckSF128<S,T> : IFunc<S,Vector128<T>,bit>
        where S : unmanaged
        where T : unmanaged
    {

    }

    [Free]
    public interface ICheckSF256<S,T> : IFunc<S, Vector256<T>, bit>
        where S : unmanaged
        where T : unmanaged
    {

    }
}