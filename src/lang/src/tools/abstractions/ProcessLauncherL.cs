//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ProcessLauncher<L> : Channeled<L>
        where L : ProcessLauncher<L>, new()
    {
        public abstract void Launch(CmdArgs args, Action<Process> launched);
    }
}