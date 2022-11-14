//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfServices : WfSvc<WfServices>, IWfServices
    {
        public static ConstLookup<Name,WfOp> defs(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,WfOp>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }

        public JsonDocument Serialize<A>(A src)
            where A : IWfAction<A>, new()
                => JsonData.document(src);

        public A Materialize<A>(JsonText src)
            where A : IWfAction<A>, new()
                => JsonData.materialize<A>(src);
    }
}