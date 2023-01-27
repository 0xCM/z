//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    
    public class AsmDbCmd : WfAppCmd<AsmDbCmd>
    {
        CultProcessor Cult => Wf.CultProcessor();

        NasmCatalog Nasm => Wf.NasmCatalog();

        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

        AsmDocs AsmDocs => Wf.AsmDocs();

        [CmdOp("stanford/etl")]
        void StanfordEtl()
            => StanfordCatalog.RunEtl();

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