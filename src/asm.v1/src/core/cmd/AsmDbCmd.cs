//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    
    class AsmDbCmd : WfAppCmd<AsmDbCmd>
    {
        CultProcessor Cult => Wf.CultProcessor();

        NasmCatalog Nasm => Wf.NasmCatalog();

        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

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
        }
    }
}