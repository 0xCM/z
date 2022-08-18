//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SpanProjector<H,S,T> : PipelineService<H>, ISpanMap<S,T>
        where H : SpanProjector<H,S,T>, new()
    {
        public void Invoke(ReadOnlySpan<S> src, Span<T> dst)
        {
            SignalStart();
            Project(src,dst);
            SignalEnd();
        }

        protected abstract uint Project(ReadOnlySpan<S> src, Span<T> dst);

        protected abstract void SignalStart();

        protected abstract void SignalEnd();
    }
}