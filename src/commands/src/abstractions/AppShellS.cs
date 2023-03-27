//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppShell<A> : AppService<A>, IAppShell
        where A : AppShell<A>, new()
    {
        public ReadOnlySeq<string> Args {get; private set;}

        protected virtual void OnExit()
        {

        }

        protected abstract void Run();
            
        void IApiShell.Run()
            => Run();

        void IAppShell.Init(IWfRuntime wf, IApiContext context, params string[] args)
        {
            Args = args;
            Init(wf,context);
        }
            
        protected abstract void Init(IWfRuntime wf, IApiContext context);
    }
}