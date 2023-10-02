//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;


partial class XedCmd
{
    XedImport XedImport => Wf.XedImport();

    [CmdOp("xed/ock")]
    void ListOcKinds()
    {
        var src = AsmOpCodes.info();
        iter(src, r => {
            Channel.RowFormat("{0} {1}", r.Name, r.Number);
        });
    }

    [CmdOp("xed/rules")]
    void LoadRuleBlocks()
    {
        var src = XedZ.rules(XedPaths.DocSource(XedDocKind.RuleBlocks));
        var domain = XedZ.domain(src);
        Channel.FileEmit(domain.Format(), XedPaths.Targets().Path("xed.instblocks.domain", FS.ext("txt")));
    }


    [CmdOp("xed/sigs")]
    void EmitSigs()
    {
        Channel.Row(AsmSigs.m16());
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
        // exec(true, 
        //     () => XedZ.emit(Channel, XedZ.rules(XedPaths.DocSource(XedDocKind.RuleBlocks))),
        //     () => Channel.TableEmit(XedRegMap.Service.REntries, XedPaths.Targets().Table<RegMapEntry>("rmap")),
        //     () => Channel.TableEmit(XedRegMap.Service.XEntries, XedPaths.Targets().Table<RegMapEntry>("xmap")),
        //     () => DataFlow.EmitChipCodes(Symbols.symkinds<ChipCode>()),
        //     () => DataFlow.EmitBroadcastDefs(Xed.broadcasts(Symbols.kinds<BroadcastKind>())),
        //     () => DataFlow.EmitCpuIdDataset(DataFlow.CalcCpuIdDataset(XedPaths.DocSource(XedDocKind.CpuId))),
        //     () => {
        //         var chips = DataFlow.CalcChipMap(XedPaths.DocSource(XedDocKind.ChipMap));
        //         DataFlow.EmitChipMap(chips);
        //         var forms = DataFlow.CalcFormImports(XedPaths.DocSource(XedDocKind.FormData));
        //         DataFlow.EmitFormImports(forms);
        //         var inst = DataFlow.CalcChipInstructions(forms, chips);
        //         DataFlow.EmitChipInstructions(inst);
        //     },
        //     () => {
        //         var widths = XedImport.Widths;
        //         DataFlow.EmitOpWidths(widths.Details);
        //         DataFlow.EmitPointerWidths(widths.Pointers.Where(x => x.Kind != 0).Map(x => x.ToRecord()));
        //     }
        // );

        // var defs = XedInstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef));
        // var patterns = InstPattern.load(defs);


    }
}
