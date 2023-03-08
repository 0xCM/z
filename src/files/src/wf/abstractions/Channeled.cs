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

        protected AppSettings Settings => AppSettings.Default;

        protected void Connect(IWfChannel channel)
        {
            Channel = channel;
        }

        IWfChannel IChanneled.Channel 
            => Channel;

        void IChanneled.Connect(IWfChannel channel)
            => Channel = channel;
            
        protected Channeled(IWfChannel channel)
        {
            Channel = channel;
        }

        protected Channeled()
        {

        }
    }
}