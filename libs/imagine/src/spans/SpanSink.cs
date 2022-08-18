//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    /// <summary>
    /// Defines a canonical table sink predicated on a process function
    /// </summary>
    public readonly struct SpanSink<T> : ISpanSink<SpanSink<T>,T>
    {
        readonly Receiver<T> Fx;

        [MethodImpl(Inline)]
        public SpanSink(Receiver<T> f)
        {
            Fx = f;
        }

        [MethodImpl(Inline)]
        public void Deposit(T x)
            => Fx(x);

        [MethodImpl(Inline)]
        public void Deposit(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                 Fx(skip(src,i));
        }
    }
}