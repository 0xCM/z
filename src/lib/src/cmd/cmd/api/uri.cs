//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var kind = CmdKind.App;
            var host = src.DeclaringType;
            var part = host.Assembly.PartName().Format();
            var attrib = src.Tag<CmdOpAttribute>();
            var name = attrib.MapValueOrElse(a => a.Name, () => src.DisplayName());
            return uri(kind,part, host.DisplayName(), name);        
        }

        public static CmdUriSeq uri<S>(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }
    }
}