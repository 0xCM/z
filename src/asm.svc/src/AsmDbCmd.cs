//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class AsmDbCmd : AppCmdService<AsmDbCmd>
    {
        IntelSdm Sdm => Wf.IntelSdm();

        CultProcessor Cult => Wf.CultProcessor();

        NasmCatalog Nasm => Wf.NasmCatalog();

        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

        AsmDocs AsmDocs => Wf.AsmDocs();

        IntelInx Intrinsics => Wf.IntelIntrinsics();
            
        SdeSvc Sde => Wf.SdeSvc();

        [CmdOp("stanford/etl")]
        void StanfordEtl()
            => StanfordCatalog.RunEtl();

        [CmdOp("sdm/etl")]
        void SdmImport()
            => Sdm.RunEtl();

        [CmdOp("sde/etl")]
        void LoadCpuidRows()
            => Sde.RunEtl();

        [CmdOp("nasm/etl")]
        void ImportNasmCatalog()
            => Nasm.RunEtl();

        [CmdOp("cult/etl")]
        void ImportCultData()
            => Cult.RunEtl();

        [CmdOp("asmdb/etl")]
        void AsmEtl()
        {
            Cult.RunEtl();
            Sdm.RunEtl();
            Sde.RunEtl();
            Intrinsics.RunEtl();
            Nasm.RunEtl();
            StanfordCatalog.RunEtl();
            EmitAsmSymbols();
            AsmDocs.Emit();
        }

        void EmitAsmSymbols()
        {
            TableEmit(AsmTokens.OcTokenDefs.View, AppDb.ApiTargets().Path("api.asm.tokens.opcodes", FileKind.Csv), UTF16);
            TableEmit(AsmTokens.SigTokenDefs.View, AppDb.ApiTargets().Path("api.asm.tokens.sigs", FileKind.Csv), UTF16);
            TableEmit(AsmTokens.TokenDefs.View, AppDb.ApiTargets().Path("api.asm.tokens", FileKind.Csv), UTF16);
        }
    }
}