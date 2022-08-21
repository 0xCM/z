//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        public static ConstLookup<Name,AppCmdDef> defs(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,AppCmdDef>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }
    }
}