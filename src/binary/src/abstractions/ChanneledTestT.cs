//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ChanneledTest]
    public abstract class ChanneledTest<T> : IChanneledTest
        where T : ChanneledTest<T>, new()
    {
        public ExecToken Run(IWfChannel channel)
        {
            _Channel = channel.Rehost(typeof(T));
            var token = ExecToken.Empty;
            var flow = channel.Running();
            try
            {
                token = Run(flow);
            }
            catch(Exception e)
            {
                Channel.Error(e.Message);
                Channel.Row(e.StackTrace);
                token = Channel.Ran(flow, false);
            }

            return token;
        }

        IWfChannel _Channel;

        protected IWfChannel Channel
        {
            [MethodImpl(Inline)]
            get => _Channel;
        }
        protected abstract ExecToken Run(ExecFlow flow);

    }
}