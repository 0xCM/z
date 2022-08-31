//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiAtomic;

    public partial class LlvmCmd : AppCmdService<LlvmCmd>
    {
        LlvmDataImporter Importer => Wf.LlvmDataImporter();

        LlvmPaths Paths => Wf.LlvmPaths();

        LlvmArchive WsArchive => new LlvmArchive(AppDb.LlvmRoot(), "llvm");

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataEmitter DataEmitter => Wf.LlvmDataEmitter();

        LlvmCodeGen CodeGen => Wf.LlvmCodeGen();

        LlvmConfigSvc Config => Wf.LlvmConfig();

        LlvmQuery Query => DataEmitter.Query;

        LlvmLineMaps LineMaps => Wf.LlvmLineMaps();

        ToolIdOld SelectedTool;

        Files TdFiles()
            => Z0.DbArchive.filter(Paths.LlvmRoot.Root, FS.ext(td)).Files().Array();

        public LlvmCmd()
        {
            SelectedTool = ToolIdOld.Empty;
        }
    }
}