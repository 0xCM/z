//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IOperation
    {
        NameOld OpName {get;}
    }

    public interface IOperation<S> : IOperation
    {

    }

    public interface IOperation<S,T> : IOperation
    {

    }
}