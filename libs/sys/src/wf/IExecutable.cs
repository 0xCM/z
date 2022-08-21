//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IExecutable
    {
        void Execute(params string[] args);

    }

    [Free]
    public interface IExecutable<A> : IExecutable
    {
        void Execute(params A[] args);
    }

    [Free]
    public interface IExecutable<M,A> : IExecutable<A>
        where M : IExecutable<M,A>, new()
    {

    }
}