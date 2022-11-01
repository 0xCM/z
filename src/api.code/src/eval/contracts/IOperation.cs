//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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