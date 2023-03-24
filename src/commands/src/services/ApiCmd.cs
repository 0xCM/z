
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiCmd : AppService<ApiCmd>, IApiService
    {                         
        public static ICmdDispatcher Dispatcher 
            => AppData.Value<ICmdDispatcher>(nameof(ICmdDispatcher));

        // public Outcome RunCmd(string name, CmdArgs args)
        //     => Dispatcher.Dispatch(name, args);

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

        // public void RunCmd(IWfChannel channel, ApiCmdSpec cmd)
        // {
        //     try
        //     {
        //         Dispatcher.Dispatch(cmd.Name, cmd.Args);
        //     }
        //     catch(Exception e)
        //     {
        //         channel.Error(e);
        //     }
        // }

        public void EmitApiCatalog()
            => EmitApiCatalog(Env.ShellData);
        
        public void EmitApiCatalog(CmdCatalog src, IDbArchive dst)
        {
            var data = src.Values;
            iter(data, x => Channel.Row(x.Uri.Name));
            Channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }

        public void EmitApiCatalog(IDbArchive dst)
            => EmitApiCatalog(ApiServers.catalog(), dst);
    }
}