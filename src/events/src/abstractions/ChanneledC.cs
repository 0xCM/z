//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Channeled<C> : Channeled, IChanneled<C>
        where C : Channeled<C>, new()
    {
        public static C create(IWfChannel channel)
            => new C().Factory(channel);

        static C connect(IWfChannel channel)
        {
            var service = new C();
            service.Connect(channel);
            return service;
        }

        public static C create(IWfChannel channel, Action<C> initializer)
        {
            var dst = create(channel);
            initializer(dst);
            return dst;
        }

        public virtual Func<IWfChannel,C> Factory => connect;

        protected Channeled(IWfChannel channel)
            : base(channel)
        {
        }

        protected Channeled()
        {

        }
    }
}