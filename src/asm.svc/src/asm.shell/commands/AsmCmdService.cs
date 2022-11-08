//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public sealed partial class AsmCmdService : WfAppCmd<AsmCmdService>
    {
        AsmCallPipe AsmCalls => Wf.AsmCallPipe();

        AsmRegSets RegSets => Service(AsmRegSets.create);

        AsmTables AsmTables => Service(Wf.AsmTables);

        ApiPacks ApiPacks => Wf.ApiPacks();

        IPolyrand Random;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiMd ApiMd => Wf.ApiMd();

        PdbSvc PdbSvc => Wf.PdbSvc();

        [CmdOp("pdb/emit")]
        void EmitApiPdbInfo()
            => PdbSvc.EmitPdbInfo(ApiMd.Parts.Index().First);

        ReadOnlySeq<HostAsmRecord> HostAsm()
        {
            var pack = ApiPacks.Current();
            var paths = pack.Archive().Tables();
            return AsmTables.LoadHostAsmRows(paths.Root);
        }

        void EmitApiAsmBlocks(IApiPack Dst)
        {
            var result = Outcome.Success;
            var dst = Dst.Table<AsmDataBlock>();
            var hostasm = HostAsm();
            var blocks = AsmTables.DistillBlocks(hostasm);
            AsmTables.EmitBlocks(blocks, dst);
        }

        Outcome AsmQueryRex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.rex";
            var counter = 0u;
            var src = ProcessAsmBuffers.records(ApiPacks.Current());
            var buffer = span<ProcessAsmRecord>(src.Count);
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.rex(src, ref i, buffer);
            var filtered = slice(buffer,0,count);
            var dst = AppDb.AppData().Path(FS.file("asm.rex", FS.Csv));
            TableEmit(@readonly(filtered), dst);
            return result;
        }

        void EmitCallTable(IApiPack src)
        {
            var blocks = ApiCode.apiblocks(src);
            AsmCalls.EmitRows(AsmDecoder.Decode(blocks.Storage), src.Analysis().Targets("calls").Root);
        }

        protected override void Initialized()
        {
            Random = Rng.wyhash64();
        }

        Outcome ExecVarScript(string SrcId, FilePath script)
        {
            const string ScriptId = "build-exe";
            var result = Outcome.Success;
            var vars = CmdVars.load(("SrcId", SrcId));
            var cmd = new CmdLine(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }
    }
}