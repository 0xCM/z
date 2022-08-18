//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    partial class Cmd
    {
        public static CmdCatalog catalog(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = sys.alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(dst);
        }

        public static SettingLookup<Name,asci64> commands(IAppCmdDispatcher src)
        {
            var actions = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = actions.Count;
            var dst = sys.alloc<Setting<Name,asci64>>(count);
            var settings = Settings.asci(dst);
            for(var i=0; i<actions.Count; i++)
                seek(dst,i) = Settings.asci(string.Format("{0}[{1:D3}]", part, i), (asci64)actions[i]);
            return Settings.asci(dst);
        }
    }
}