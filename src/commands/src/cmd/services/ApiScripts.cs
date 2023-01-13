//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ApiScripts
    {
        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args)
        {
            ExecToken exec()
            {
                var src = FS.path(args[0]);
                var flow = channel.Running($"Executing api scripts from {src}");
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(Cmd.parse(content, out ApiCmdSpec spec))
                    {
                        RunCmd(channel,spec);
                    }
                    else
                    {
                        channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
                return channel.Ran(flow);
            }
            return sys.start(exec);
        }   

        public static Task<ExecToken> start(IWfChannel channel, FilePath src)
        {
            ExecToken Exec()
            {
                var running = channel.Running($"Executing script {src}");
                if(src.Missing)
                {
                    channel.Error(AppMsg.FileMissing.Format(src));
                }
                else
                {
                    var lines = src.ReadNumberedLines(true);
                    var count = lines.Count;
                    for(var i=0; i<count; i++)
                    {
                        ref readonly var content = ref lines[i].Content;
                        if(Cmd.parse(content, out ApiCmdSpec spec))
                            RunCmd(channel,spec);
                        else
                        {
                            channel.Error($"ParseFailure:'{content}'");
                            break;
                        }
                    }
                }
                return channel.Ran(running);
            }
            return sys.start(Exec);        
        }

        static void RunCmd(IWfChannel channel, ApiCmdSpec cmd)
        {
            try
            {
                ApiCmd.Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
        }
    }
}