//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITaskRunner
    {
        Task<Outcome> RunAsync(CmdArgs args);

        Outcome Run(CmdArgs args);
    }

    [Free]
    public interface ITaskRunner<S,T> : ITaskRunner
    {
        T Run(S src);

        Task<T> RunAsync(S src);
    }


    [Free]
    public interface ITaskRunner<T> : ITaskRunner<CmdArgs,Outcome<T>>
    {
        new Outcome<T> Run(CmdArgs args);

        new Task<Outcome<T>> RunAsync(CmdArgs args);

        Task<Outcome> ITaskRunner.RunAsync(CmdArgs args)
            => core.start(() => (Outcome)Run(args));

        Outcome ITaskRunner.Run(CmdArgs args)
            => Run(args);
    }
}