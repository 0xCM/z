//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AppMsgExchange : IMessageQueue
    {
        readonly IMessageQueue Queue;

        /// <summary>
        /// Creates an exchange and underlying queue
        /// </summary>
        public static AppMsgExchange Create()
            => new AppMsgExchange(MessageQueue.Create());

        public AppMsgExchange(IMessageQueue dst)
        {
            Queue = dst;
            Queue.Next += Relay;
            Next = x => {};
        }

        void Relay(IAppMsg src)
        {
            term.print(src);
        }

        public event Action<IAppMsg> Next;

        [MethodImpl(Inline)]
        public void Notify(string msg, LogLevel? severity = null)
        {
           Queue.Notify(msg, severity);
        }

        public IReadOnlyList<IAppMsg> Dequeue()
            => Queue.Dequeue();

        public void Emit(FileUri dst)
            => Queue.Emit(dst);

        public IReadOnlyList<IAppMsg> Flush(Exception e)
        {
            var messages = Queue.Flush(e);
            sys.iter(messages, msg => term.print(msg));
            return messages;
        }

        public void Flush(Exception e, IMessageSink target)
            => target.Deposit(Flush(e));

        public void Deposit(IAppMsg msg)
            => Queue.Deposit(msg);
    }
}