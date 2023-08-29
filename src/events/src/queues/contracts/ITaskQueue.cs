//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface ITaskQueue
{
    ValueTask Enqueue(Func<CancellationToken, ValueTask> work);

    ValueTask<Func<CancellationToken, ValueTask>> Dequeue(CancellationToken ct);
}
