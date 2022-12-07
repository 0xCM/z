
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {
        public CmdUriSeq CmdUris()
            => uris(Dispatcher);

        public static CmdUri uri(string name, object host)
            => new(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), name);

        public static CmdUriSeq uris(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var host = src.DeclaringType;
            var name = src.Tag<CmdOpAttribute>().MapValueOrElse(a => a.Name, () => src.DisplayName());
            return Cmd.uri(CmdKind.App, host.Assembly.PartName().Format(), host.DisplayName(), name);        
        }
    }
}