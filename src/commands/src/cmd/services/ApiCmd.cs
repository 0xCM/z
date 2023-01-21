
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

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

        public void EmitCmdDefs(Assembly[] src, IDbArchive dst)
            => Cmd.emit(Channel, Cmd.defs(src), dst);

        public void RunCmd(IWfChannel channel, ApiCmdSpec cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
        }

        public void EmitApiCatalog()
            => EmitApiCatalog(Env.ShellData);
        
        public void EmitApiCatalog(CmdCatalog src, IDbArchive dst)
            => emit(Channel, src, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        public void EmitApiCatalog(IDbArchive dst)
            => EmitApiCatalog(ApiServers.catalog(), dst);

        static void emit(IWfChannel channel, CmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            CsvTables.emit(channel, data, dst);
        }
    }
}