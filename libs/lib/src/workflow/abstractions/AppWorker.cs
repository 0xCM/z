//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AppWorker<W,S,T> : IProcessor<S,T>
        where W : AppWorker<W,S,T>, new()
    {
        public abstract Task Process(S src, T dst, CancellationToken cancel);

        public virtual void Process(S src, T dst)
        {
            using var ct = new CancellationTokenSource();
            var task = Process(src, dst, ct.Token);
            task.Wait();
        }

        protected AppWorker()
        {

        }
    }
}