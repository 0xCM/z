//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Launcher<L> : Channeled<L>
        where L : Launcher<L>, new()
    {
        public abstract void Launch(CmdArgs args, Action<Process> launched);
    }
}