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

        public void Init(IWfChannel channel)
        {
            Channel = channel;
            Initialized();
        }

        protected virtual void Initialized()  {}

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