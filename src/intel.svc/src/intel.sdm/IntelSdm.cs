//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class IntelSdm : WfSvc<IntelSdm>
    {
        IntelSdmPaths SdmPaths => Wf.SdmPaths();
        
        TextMap SigNormalRules
            => data(nameof(SigNormalRules), () => Rules.textmap(SdmPaths.SigNormalConfig()));

        TextReplace OcFixupRules
            => data(nameof(OcFixupRules), () => Rules.replace(SdmPaths.OcFixupConfig()));

        TextReplace SigFixupRules
            => data(nameof(SigFixupRules), () => Rules.replace(SdmPaths.SigFixupConfig()));

        void Clear()
        {
            SdmPaths.Targets().Clear();
            ClearCache();
        }

        public void RunEtl()
        {
            var running = Running();
            try
            {
                Clear();
                ExportTokens();
                ExportOpCodes();
                ExportCharMaps();
                ImportVolumes();
                ExportSplitDefs();
                ExportToc();
            }
            catch(Exception e)
            {
                Emitter.Error(e);
            }

            Ran(running);
        }
   }
}