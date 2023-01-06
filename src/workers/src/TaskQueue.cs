//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading.Channels;

    public interface ITaskQueue
    {
        ValueTask Enqueue(Func<CancellationToken, ValueTask> work);

        ValueTask<Func<CancellationToken, ValueTask>> Dequeue(CancellationToken ct);
    }

    public class TaskQueue : ITaskQueue
    {
        readonly Channel<Func<CancellationToken, ValueTask>> _queue;

        public TaskQueue(int capacity)
        {
            BoundedChannelOptions options = new(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<Func<CancellationToken, ValueTask>>(options);
        }

        public async ValueTask Enqueue(Func<CancellationToken, ValueTask> work)
        {
            await _queue.Writer.WriteAsync(work);
        }

        public async ValueTask<Func<CancellationToken, ValueTask>> Dequeue(
            CancellationToken cancellationToken)
        {
            Func<CancellationToken, ValueTask>? workItem =
                await _queue.Reader.ReadAsync(cancellationToken);

            return workItem;
        }
    }

}