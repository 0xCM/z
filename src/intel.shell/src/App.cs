//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
sealed class App : ApiShell<App>
{
    public static int Main(params string[] args)
    {
        var result = 0;
        using var app = ApiServer.app<App>(args);
        try
        {
            if(args.Length == 0)
                app.Run();
            else
                app.Runner.RunCommand(ApiServer.command(args));
        }
        catch(Exception e)
        {
            term.error(e);
            result = -1;
        }
        return result;
    }
}
