
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {
        public static void dispatch(IWfContext context, FilePath defs)
        {
            if(defs.Missing)
            {
                context.Channel.Error(AppMsg.FileMissing.Format(defs));
            }
            else
            {
                var lines = defs.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(parse(content, out ApiCmdSpec spec))
                    {
                        context.Dispatcher.Dispatch(spec.Name, spec.Args);
                    }
                    else
                    {
                        context.Channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out ApiCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new ApiCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = sys.@string(SQ.left(src,i));
                var _args = sys.@string(SQ.right(src,i)).Split(Chars.Space);
                dst = new ApiCmdSpec(name, Cmd.args(_args));
            }
            return true;
        }        
    }
}
