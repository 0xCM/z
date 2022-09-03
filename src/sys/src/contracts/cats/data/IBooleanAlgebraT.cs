//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IAlgebra<T>
    {

    }

    [Free]
    public interface IBooleanAlgebra<T> : IAlgebra<T>
    {
        T True {get;}

        T False {get;}

        T And(T a, T b);

        T Or(T a, T b);

        T Not(T a);
    }
}