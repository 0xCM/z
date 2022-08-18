//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAddress<F,T> : IAddress<T>, IDataType<F>
        where F : unmanaged, IAddress<F,T>
        where T : unmanaged
    {

    }
}