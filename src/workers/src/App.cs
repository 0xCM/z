//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    class App
    {
        public static int Main(string[] args)
        {
            var result = 0;
            // if(args.Length == 0)
            //     term.print($"Usage: {Assembly.GetEntryAssembly().GetSimpleName()} <path>");
            // else
            //     CreateHostBuilder(ApiServer.runtime(), args).Build().Run();
            return result;
        }

        // static IServiceCollection configure(IWfRuntime wf, HostBuilderContext context, IServiceCollection services, string[] args)
        // {
        //     AppController AddController(IServiceProvider provider)
        //         => new (wf, provider.GetService<ILogger<AppController>>(), args);
        //     return services.AddHostedService(AddController);
        // }

        // public static IHostBuilder CreateHostBuilder(IWfRuntime wf, string[] args)
        //     => Host.CreateDefaultBuilder(args)
        //         .ConfigureServices((c,s) => configure(wf,c,s, args));
    }
}