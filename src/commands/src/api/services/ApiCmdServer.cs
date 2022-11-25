//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiCmdServer : ApiServer<ApiCmdServer>
    {
        [CmdOp("commands")]
        void EmitCommands()
            => ApiCmd.emit(Channel, ApiCmd.catalog(), AppDb.AppData().Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
    }
}