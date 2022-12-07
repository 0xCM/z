
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {
        public static Task<ExecToken> dispatch(IApiContext context, FilePath src)
        {
            ExecToken exec()
            {
                var channel = context.Channel;
                var flow = channel.Running($"Executing api scripts from {src}");
                var lines = src.ReadNumberedLines(true);
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
                return channel.Ran(flow);
            }
            return start(exec);
        }
    }
}
