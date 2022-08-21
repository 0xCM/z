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
    public interface IRunnable<C>
    {
        void Run(C context);

        Task Start(C context)
            => Task.Run(() => Run(context));
    }
}