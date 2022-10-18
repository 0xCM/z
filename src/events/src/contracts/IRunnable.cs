//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRunnable
    {
        void Run();

        Task Start()
            => Task.Run(Run);
    }

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

    [Free]
    public interface IRunnable<C>
    {
        void Run(C state);

        Task Start(C state)
            => Task.Run(() => Run(state));
    }

    [Free]
    public interface IRunnable<S,T>
    {
        T Run(S state);

        Task<T> Start(S state)
            => Task.Run(() => Run(state));
    }

    [Free, Runnable]
    public abstract class Runnable<R,S,T> : IRunnable<S,T>
        where R : IRunnable<S,T>, new()
    {
        public abstract T Run(S state);

        public Task<T> Start(S state)
            => Task.Run(() => Run(state));
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class RunnableAttribute : Attribute
    {

    }
}