//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class IntelSdm : WfSvc<IntelSdm>
    {
        CharMapper CharMapper => Service(Wf.CharMapper);

        IntelSdmPaths SdmPaths => Wf.SdmPaths();
        
        TextMap SigNormalRules
            => data(nameof(SigNormalRules), () => Rules.textmap(SdmPaths.SigNormalConfig()));

        TextReplace OcFixupRules
            => data(nameof(OcFixupRules), () => Rules.replace(SdmPaths.OcFixupConfig()));

        TextReplace SigFixupRules
            => data(nameof(SigFixupRules), () => Rules.replace(SdmPaths.SigFixupConfig()));

        void Clear()
        {
            SdmPaths.Output().Clear();
            ClearCache();
        }

        public void RunEtl()
        {
            var running = Running();
            try
            {
                Clear();
                EmitTokens();
                Emit(CalcOcDetails());

                EmitCharMaps();

                ImportVolume(1);

                ImportVolume(2);

                ImportVolume(3);

                ImportVolume(4);

                EmitSdmSplits();

                EmitCombinedToc();

                EmitTocRecords();

            }
            catch(Exception e)
            {
                Emitter.Error(e);
            }

            Ran(running);
        }
   }
}