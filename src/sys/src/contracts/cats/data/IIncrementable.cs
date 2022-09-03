//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IIncrementable<T> : IOrdered<T>
    {
        T Inc();
    }


    [Free]
    public interface IIncrementable<F,T> : IIncrementable<T>
        where F : IIncrementable<F,T>, new()
    {

    }
}