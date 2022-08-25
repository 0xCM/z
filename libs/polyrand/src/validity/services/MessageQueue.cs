//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    class MessageQueue : IMessageQueue
    {
        object lockobj = new object();

        public event Action<IAppMsg> Next;

        List<IAppMsg> Messages {get;}

        [MethodImpl(Inline)]
        public static MessageQueue Create()
            => new MessageQueue();

        [MethodImpl(Inline)]
        MessageQueue()
        {
            Messages = new List<IAppMsg>();
            Next = x => {};
        }

        [MethodImpl(Inline)]
        void Relay(IAppMsg msg)
            => Next(msg);

        public IReadOnlyList<IAppMsg> Dequeue()
        {
            lock(lockobj)
            {
                var messages = Messages.ToArray();
                Messages.Clear();
                return messages;
            }
        }

        public void Deposit(IAppMsg msg)
        {
            lock(lockobj)
                Messages.Add(msg);

            Relay(msg);
        }

        public IReadOnlyList<IAppMsg> Flush(Exception e)
        {
            lock(lockobj)
            {
                Deposit(AppMsg.define($"{e}", LogLevel.Error));
                return Dequeue();
            }
        }

        public void Notify(string msg, LogLevel? severity = null)
            => Deposit(AppMsg.define($"{msg}", severity ?? LogLevel.Babble));

        public void Emit(FilePath dst)
        {
            try
            {
                using var writer = dst.Writer();
                iter(Dequeue(), msg => writer.WriteLine(msg.Format()));
            }
            catch(Exception)
            {
                term.red($"Error writing to {dst}");
                throw;
            }
        }
    }
}