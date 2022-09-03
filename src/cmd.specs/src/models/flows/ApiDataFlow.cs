//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ApiDataFlow : IDataFlow
    {
        public static Index<ApiDataFlow> discover(Assembly[] src)
        {
            var types = src.Types().Concrete().Tagged<DataFlowAttribute>();
            var count = types.Length;
            var buffer = alloc<ApiDataFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var f = type.Field("Instance");
                seek(buffer,i) = new ApiDataFlow((IDataFlow)f.GetValue(null));
            }
            return buffer;
        }

        public static ApiDataFlow<S,T> typed<S,T>(ApiDataFlow src)
            => new ApiDataFlow<S,T>((IDataFlow<S,T>)(IDataFlow)src);

        readonly IDataFlow Flow;

        [MethodImpl(Inline)]
        public ApiDataFlow(IDataFlow flow)
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