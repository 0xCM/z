//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct DataFlow : IDataFlow
    {
        public static Index<DataFlow> discover(Assembly[] src)
        {
            var types = src.Types().Concrete().Tagged<DataFlowAttribute>();
            var count = types.Length;
            var buffer = alloc<DataFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var f = type.Field("Instance");
                seek(buffer,i) = new DataFlow((IDataFlow)f.GetValue(null));
            }
            return buffer;
        }

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