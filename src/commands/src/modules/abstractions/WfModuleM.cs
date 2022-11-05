//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WfModule<M> : WfModule, IWfModule<M>
        where M : WfModule<M>,new()
    {
        public static M create(IWfChannel channel)
        {
            var module = new M();
            module.Channel = channel;
            return module;
        }
    }
}