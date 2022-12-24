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
}