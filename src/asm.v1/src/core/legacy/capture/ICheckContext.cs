//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a context that carries and provides access to a composition
    /// </summary>
    public interface ICheckContext : IMessageQueue, IPolyrandProvider
    {
        IMessageQueue MessageQueue {get;}

        Action<IAppMsg> MessageRelay
            => (e => term.print(e));

        void ISink<IAppMsg>.Deposit(IAppMsg msg)
            => MessageQueue.Deposit(msg);

        void IMessageSink.Notify(string msg, LogLevel? severity)
            => MessageQueue.Notify(msg, severity);

        IReadOnlyList<IAppMsg> IMessageQueue.Dequeue()
            => MessageQueue.Dequeue();

        IReadOnlyList<IAppMsg> IMessageQueue.Flush(Exception e)
            => MessageQueue.Flush(e);

        void IMessageQueue.Emit(FileUri dst)
            => MessageQueue.Emit(dst);
    }
}