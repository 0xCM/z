//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[ApiHost]
public partial class IntelSdm : WfSvc<IntelSdm>
{
    IntelSdmPaths SdmPaths => Wf.SdmPaths();
    
    static readonly AsmDocs AsmDocs = new();
    
    TextMap SigNormalRules
        => data(nameof(SigNormalRules), () => TextMap.load(SdmPaths.SigNormalConfig()));

    TextReplacements OcFixupRules
        => data(nameof(OcFixupRules), () => TextReplacements.load(SdmPaths.OcFixupConfig()));

    TextReplacements SigFixupRules
        => data(nameof(SigFixupRules), () => TextReplacements.load(SdmPaths.SigFixupConfig()));

    void Clear()
    {
        SdmPaths.Targets().Clear();
        ClearCache();
    }

    public void RunEtl()
    {
        var running = Channel.Running();
        try
        {
            Clear();
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

        Channel.Ran(running);
    }
}
