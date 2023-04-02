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

        public void Init(IWfRuntime wf, ReadOnlySeq<string> args)
        {
            base.Init(wf);
            Args = args;
        }

        protected virtual void OnExit()
        {

        }

        protected abstract void Run();

        void IAppShell.Run()
        {
            Run();
        }
    }
}