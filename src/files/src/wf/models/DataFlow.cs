//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataFlow : IDataFlow
    {
        public static DataFlow<S,T> typed<S,T>(DataFlow src)
            => new DataFlow<S,T>((IDataFlow<S,T>)(IDataFlow)src);

        readonly IDataFlow Flow;

        [MethodImpl(Inline)]
        public DataFlow(IDataFlow flow)
        {
            Flow = flow;
        }

        public Actor Actor => Flow.Actor;

        public dynamic Source => Flow.Source;

        public dynamic Target => Flow.Target;

        public string Format()
            => Flow.Format();

        public override string ToString()
            => Format();
    }
}