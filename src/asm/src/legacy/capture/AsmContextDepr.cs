//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    class AsmContextDepr : IAsmContextDepr
    {
        public IWfRuntime Wf {get;}

        public IMessageQueue MessageQueue {get;}

        public event Action<IAppMsg> Next;

        public IPolyrand Random {get;}

        public AsmDecoder Decoder {get;}

        public AsmFormatConfig FormatConfig {get;}

        [MethodImpl(Inline)]
        public AsmContextDepr(ICheckContext app, IWfRuntime wf)
        {
            Wf = wf;
            Decoder = wf.AsmDecoder();
            FormatConfig = AsmFormatConfig.@default(out var _);
            MessageQueue = app.MessageQueue;
            Next = app.MessageRelay;
            app.MessageQueue.Next += Relay;
            Random = app.Random;
        }

        [MethodImpl(Inline)]
        void Relay(IAppMsg msg)
            => Next(msg);

        public void Deposit(IAppMsg msg)
            => MessageQueue.Deposit(msg);

        public void Notify(string msg, LogLevel? severity = null)
            => MessageQueue.Notify(msg, severity);

        public IReadOnlyList<IAppMsg> Dequeue()
            => MessageQueue.Dequeue();

        public IReadOnlyList<IAppMsg> Flush(Exception e)
            => MessageQueue.Flush(e);

        public void Emit(FileUri dst)
            => MessageQueue.Emit(dst);
    }
}