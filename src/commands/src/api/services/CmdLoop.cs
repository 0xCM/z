
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdLoop
    {
        static ICmdDispatcher Dispatcher => ApiCmd.Dispatcher;

        public static Task start(IWfChannel channel)
        {
            var loop = new CmdLoop(channel);
            return(sys.start(loop.Run));
        }
            
        readonly IWfChannel Channel;

        CmdLoop(IWfChannel channel)
        {
            Channel = channel;
        }

        ApiCmdSpec Next()
        {
            var input = term.prompt(string.Format("{0}> ", "cmd"));
            if(Cmd.parse(input, out ApiCmdSpec cmd))
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
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}