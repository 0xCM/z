//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Channeled]
    public abstract class Channeled : IChanneled
    {
        protected IWfChannel Channel;

        IWfChannel IChanneled.Channel 
            => Channel;

        protected Channeled(IWfChannel channel)
        {
            Channel = channel;
        }

        protected Channeled()
        {

        }
    }
}