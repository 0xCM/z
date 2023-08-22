//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IMessageQueue : IMessageSink, ICallbackSource<IAppMsg>
{
    IReadOnlyList<IAppMsg> Dequeue();

    void Emit(FileUri dst);

    IReadOnlyList<IAppMsg> Flush(Exception e);

    void Flush(Exception e, IMessageSink target)
        => target.Deposit(Flush(e));
}
