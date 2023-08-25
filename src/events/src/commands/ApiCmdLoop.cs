//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class ApiCmdLoop
{
    public static Task start(IWfChannel channel, IApiCmdRunner runner)
        => sys.start(new ApiCmdLoop(channel, runner).Run);

    readonly IWfChannel Channel;

    readonly IApiCmdRunner Runner;

    ApiCmdLoop(IWfChannel channel, IApiCmdRunner runner)
    {
        Channel = channel;
        Runner = runner;
    }

    ApiCommand Next()
    {
        var input = term.prompt(string.Format("{0}> ", "cmd"));
        return ApiServer.command(input);
    }

    void Run()
    {
        var input = Next();
        while(input.Route != ".exit")
        {
            if(input.IsNonEmpty)
                RunCmd(input);
            input = Next();
        }
    }
        
    void RunCmd(ApiCommand cmd)
    {
        try
        {
            Runner.RunCommand(cmd);
        }
        catch(Exception e)
        {
            Channel.Error(e);
        }
    }
}
