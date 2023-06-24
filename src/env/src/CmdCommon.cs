//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    sealed class CmdCommon : WfAppCmd<CmdCommon>
    {
        [CmdOp("commands")]
        void Run(CmdArgs args)
            => emit(Channel, ApiServers.catalog(), EnvDb);

        [CmdOp("env/reports")]
        void EmitEnv(IApiContext context, CmdArgs args)
        {
            if(args.IsNonEmpty)
            {
                EnvId name = args[0].Value;
                var cfg = EnvReports.GetEnvConfig(name);
                var report = cfg.Report();
                var tools = report.Tools;
                iter(tools, tool => Channel.Row(tool));
                iter(report.Vars, v => Channel.Row(v));                
            }
                
            else
                EnvReports.emit(Channel);
        }

        static void emit(IWfChannel channel, ApiCmdCatalog src, IDbArchive dst)
        {
            var data = src.Commands;
            iter(data, x => channel.Row(x.Uri.Name));
            channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }
    }
}