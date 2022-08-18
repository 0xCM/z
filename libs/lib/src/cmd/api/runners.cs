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
        [Op]
        public static AppCmdRunner runner(string name, object host, MethodInfo method)
            => new AppCmdRunner(name,host,method);

        [Op]
        public static Index<AppCmdRunner> runners(object host)
        {
            var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
            var buffer = sys.alloc<AppCmdRunner>(methods.Length);
            runners(host, methods,buffer);
            return buffer;
        }

        static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<AppCmdRunner> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = runner(tag.Name, host, method);
            }
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
    }
}