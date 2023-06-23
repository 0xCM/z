//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    sealed class ApiMdCmd : WfAppCmd<ApiMdCmd>
    {
        [CmdOp("commands")]
        void Run(CmdArgs args)
            => emit(Channel, ApiServers.catalog(), EnvDb);

        static void emit(IWfChannel channel, ApiCmdCatalog src, IDbArchive dst)
        {
            var data = src.Commands;
            iter(data, x => channel.Row(x.Uri.Name));
            channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }
    }
}