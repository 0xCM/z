//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiModule<M> : ApiModule, IApiModule<M>
        where M : ApiModule<M>,new()
    {
        public static M create(IWfChannel channel)
        {
            var module = new M();
            module.Channel = channel;
            return module;
        }
    }
}