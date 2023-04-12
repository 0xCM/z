
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdLoop
    {
        public static Task start(IWfChannel channel, IApiCmdRunner runner)
            => sys.start(new CmdLoop(channel, runner).Run);

        readonly IWfChannel Channel;

        readonly IApiCmdRunner Runner;

        CmdLoop(IWfChannel channel, IApiCmdRunner runner)
        {
            Channel = channel;
            Runner = runner;
        }

        ApiCmdSpec Next()
        {
            var input = term.prompt(string.Format("{0}> ", "cmd"));
            if(ApiCmd.parse(input, out ApiCmdSpec cmd))
            {
                return cmd;
            }
            else
            {
                Channel.Error($"ParseFailure:{input}");
                return ApiCmdSpec.Empty;
            }
        }

        void Run()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                    RunCmd(input);
                input = Next();
            }
        }
            
        void RunCmd(ApiCmdSpec cmd)
        {
            try
            {
                Runner.RunCommand(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}