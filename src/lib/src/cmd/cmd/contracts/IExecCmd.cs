//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IExecSpec
    {

    }

    public interface IExecSpec<E> : IExecSpec
    {

    }

    [Free]
    public interface IExecCmd<C,E>
        where C : IExecCmd<C,E>
        where E : IExecSpec

    {

    }
}