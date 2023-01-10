//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using D = Delegates;

    /// <summary>
    /// Characterizes an emitter that shoots out spans
    /// </summary>
    /// <typeparam name="T">The span element type</typeparam>
    [Free, SFx]
    public interface ISpanProducer<T> : IFunc
    {
        Span<T> Invoke();
    }

    partial class Surrogates
    {
        /// <summary>
        /// Captures a delegate that is exposed as an emitter
        /// </summary>
        public readonly struct SpanProducer<T> : ISpanProducer<T>
        {
            readonly D.SpanProducer<T> F;

            public OpIdentity Id {get;}

            [MethodImpl(Inline)]
            public SpanProducer(D.SpanProducer<T> f, OpIdentity id)
            {
                F = f;
                Id = id;
            }

            [MethodImpl(Inline)]
            public Span<T> Invoke()
                => F();

            public D.SpanProducer<T> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }
        }
    }
}