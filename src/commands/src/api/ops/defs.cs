
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {

        public ConstLookup<Name,ApiOp> CmdDefs()
            => defs(Dispatcher);

        static ConstLookup<Name,ApiOp> defs(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,ApiOp>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }
    }
}