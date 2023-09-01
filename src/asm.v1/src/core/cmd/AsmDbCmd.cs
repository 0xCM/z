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

        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

        [CmdOp("stanford/etl")]
        void StanfordEtl()
            => StanfordCatalog.RunEtl();

        [CmdOp("cult/etl")]
        void ImportCultData()
            => Cult.RunEtl();

        [CmdOp("asmdb/etl")]
        void AsmEtl()
        {
            Cult.RunEtl();
            StanfordCatalog.RunEtl();            
        }
    }
}