//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ChildProcess<P> : ChildProcess
        where P : ChildProcess<P>, new()
    {
        protected ChildProcess()
        {
            
        }

        protected ChildProcess(Process process)
            : base(process)
        {
            
        }
    }
}