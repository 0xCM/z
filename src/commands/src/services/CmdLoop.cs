
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public abstract class RunLoop
    {

    }

    public abstract class RunLoop<L> : RunLoop
        where L : RunLoop<L>, new()
    {

    }    

    public class CmdLoop
    {
        public static Task start(IWfChannel channel)
            => sys.start(new CmdLoop(channel).Run);

        public static Task start(IWfChannel channel, ICmdDispatcher dispatcher)
            => sys.start(new CmdLoop(channel, dispatcher).Run);

        readonly IWfChannel Channel;

        readonly ICmdDispatcher Dispatcher;

        CmdLoop(IWfChannel channel, ICmdDispatcher dispatcher)
        {
            Channel = channel;
            Dispatcher = dispatcher;
        }

        CmdLoop(IWfChannel channel)
        {
            Channel = channel;
            Dispatcher = ApiServers.Dispatcher;
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