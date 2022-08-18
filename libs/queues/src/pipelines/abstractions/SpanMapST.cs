//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public sealed class SpanProjector<S,T> : SpanProjector<SpanProjector<S,T>,S,T>
    {
        ISpanMap<S,T> Map;

        public SpanProjector()
        {

        }

        uint Counter;

        public SpanProjector<S,T> With(ISpanMap<S,T> map)
        {
            Map = map;
            return this;
        }

        protected override uint Project(ReadOnlySpan<S> src, Span<T> dst)
        {
            Map.Invoke(src,dst);
            Counter = (uint)dst.Length;
            return Counter;
        }

        protected override void SignalStart()
        {
            Signal.Running(string.Format("{0}* -> {1}*", typeof(S).Name, typeof(T).Name));
        }

        protected override void SignalEnd()
        {
            Signal.Running(string.Format("{0}* -> {1}* {(2)}", typeof(S).Name, typeof(T).Name, Counter));
        }
    }
}