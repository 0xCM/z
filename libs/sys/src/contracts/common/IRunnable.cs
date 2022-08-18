//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRunnable
    {
        void Run();

        Task Start()
            => Task.Run(Run);
    }

    [Free]
    public interface IRunnable<C> : IRunnable
        where C : new()
    {
        C Settings {get;}
    }

    [Free]
    public interface IRunnable<C,S,T> : IRunnable<C>
        where C : new()
    {
        void Run(S src, T dst);

        Task Start(S src, T dst)
            => Task.Run(Run);
    }
}