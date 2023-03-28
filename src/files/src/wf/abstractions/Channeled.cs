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

        protected static AppSettings Settings => AppSettings.Default;

        protected static AppDb AppDb => AppDb.Service;

        protected static IEnvDb EnvDb => Settings.EnvDb();

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