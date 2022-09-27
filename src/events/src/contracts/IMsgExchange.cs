//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMsgExchange : IMessageQueue
    {
        void IMessageSink.Deposit(IEnumerable<IAppMsg> msg)
        {}

        void IMessageSink.Notify(string msg, LogLevel? kind)
        {}

        void IMessageSink.NotifyConsole(IAppMsg msg)
        {
        }

        void ISink<IAppMsg>.Deposit(IAppMsg src)
        {}

        IReadOnlyList<IAppMsg> IMessageQueue.Dequeue()
            => sys.empty<IAppMsg>();

        void IMessageQueue.Emit(FileUri dst)
        {}

        IReadOnlyList<IAppMsg> IMessageQueue.Flush(Exception e)
            => sys.empty<IAppMsg>();

        void IAppMsgQueueFlush(Exception e, IMessageSink target)
        {}
    }
}