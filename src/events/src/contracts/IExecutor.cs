//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IExecutor : IRunnable
{
    Type ExecutorType {get;}

    void Run(dynamic context);

    Type ContextType
        => typeof(void);
}

public interface IExecutor<P> : IExecutor
    where P : IExecutor<P>
{
    Type IExecutor.ExecutorType
        => typeof(P);
}

public interface IExecutor<P,C> : IExecutor<P>
    where P : IExecutor<P>
{
    void Run(C context);

    void IExecutor.Run(dynamic context)
        => Run((C)context);

    Type IExecutor.ContextType
        => typeof(C);
}
