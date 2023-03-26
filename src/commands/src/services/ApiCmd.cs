
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiCmd : AppService<ApiCmd>, IApiService
    {                         
        public void RunCmd(string name)
        {
            var result = ApiServers.Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

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