//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppShell<A> : AppService<A>, IAppShell
        where A : AppShell<A>, new()
    {
        protected virtual void OnExit()
        {

        }

        protected abstract void Run(string[] args);

        void IAppShell.OnExit()
            => OnExit();
            
        void IAppShell.Run(string[] args)
            => Run(args);
    }
}