//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfResult<C>
        where C : IWfCmd<C>, new()        
    {
        public readonly WfTask<C> Task;

        public readonly ExecToken Token;

        [MethodImpl(Inline)]
        public WfResult(WfTask<C> task, ExecToken token)
        {
            Task = task;
            Token = token;
        }
    }
}