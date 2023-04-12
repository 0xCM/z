
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiCmdSvc : WfSvc<ApiCmdSvc>, IApiService
    {                         
        public void RunCmd(string name)
        {
            CmdRunner.RunCommand(name);
        }

        public void EmitApiCatalog()
            => EmitApiCatalog(Env.ShellData);
        
        public void EmitApiCatalog(ApiCmdCatalog src, IDbArchive dst)
        {
            var data = src.Values;
            iter(data, x => Channel.Row(x.Uri.Name));
            Channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }

        public void EmitApiCatalog(IDbArchive dst)
            => EmitApiCatalog(ApiServers.catalog(), dst);
    }
}