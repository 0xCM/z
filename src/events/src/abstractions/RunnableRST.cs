//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, Runnable]
    public abstract class Runnable<R,S,T> : IRunnable<S,T>
        where R : IRunnable<S,T>, new()
    {
        public abstract T Run(S state);

        public Task<T> Start(S state)
            => Task.Run(() => Run(state));
    }
}