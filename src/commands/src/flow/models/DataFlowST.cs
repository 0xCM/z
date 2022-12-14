//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataFlow<S,T> : IDataFlow<S,T>
    {
        readonly IDataFlow<S,T> Flow;

        [MethodImpl(Inline)]
        public DataFlow(IDataFlow<S,T> flow)
        {
            Flow = flow;
        }

        public Actor Actor => Flow.Actor;

        public S Source => Flow.Source;

        public T Target => Flow.Target;

        public string Format()
            => Flow.Format();

        public override string ToString()
            => Format();

        public static implicit operator DataFlow<S,T>(DataFlow src)
            => DataFlow.typed<S,T>(src);
    }
}