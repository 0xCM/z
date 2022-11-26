//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiShell<S> : AppShell<S>
        where S : ApiShell<S>, new()
    {
        protected IApiService Commander;

        protected override void Disposing()
        {
            Commander?.Dispose();
        }

        protected override void Run(string[] args)
            => ApiLoop.start(Channel).Wait();
    }
}