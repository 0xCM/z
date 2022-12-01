
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdDispatcher
    {
        Task<ExecToken> Dispatch(ICmd cmd);
    }

    public interface ICmdDispatcher<C> : ICmdDispatcher
        where C : ICmd, new()
    {
        Task<ExecToken> Dispatch(C cmd);

        Task<ExecToken> ICmdDispatcher.Dispatch(ICmd cmd)
            => Dispatch((C)cmd);
    }

    public interface ICmdEmitter
    {
        bool Next(out ICmd cmd);
    }

    public interface ICmdEmitter<C> : ICmdEmitter
        where C : ICmd, new()
    {
        bool Next(out C cmd);

        bool ICmdEmitter.Next(out ICmd cmd)
        {
            var result = Next(out var c);
            cmd = c;
            return result;
        }
    }

    public interface IApiLoop : IRunnable
    {


    }


    public class ApiLoop
    {
        static IApiDispatcher Dispatcher => ApiCmd.Dispatcher;

        public static Task start(IWfChannel channel)
        {
            var loop = new ApiLoop(channel);
            return(sys.start(loop.Run));
        }
            
        readonly IWfChannel Channel;

        ApiLoop(IWfChannel channel)
        {
            Channel = channel;
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
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}