//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfTask<C>
        where C : IWfCmd<C>, new()        
    {
        public readonly C Command;

        [MethodImpl(Inline)]
        public WfTask(C cmd)
        {
            Command = cmd;
        }

        [MethodImpl(Inline)]
        public static implicit operator WfTask<C>(C cmd)
            => new WfTask<C>(cmd);
    }
}