//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedModels;
    
    partial class XedCmd
    {
        [CmdOp("xed/etl")]
        void RunImport()
        {
            exec(true, 
                () => Channel.TableEmit(XedRegMap.Service.REntries, XedDb.Targets().Table<RegMapEntry>("rmap")),
                () => Channel.TableEmit(XedRegMap.Service.XEntries, XedDb.Targets().Table<RegMapEntry>("xmap")),
                () => DataFlow.EmitChipCodes(Symbols.symkinds<ChipCode>()),
                () => DataFlow.EmitBroadcastDefs(Xed.broadcasts(Symbols.kinds<BCastKind>())),
                () => {
                    var cpuid = DataFlow.CalcCpuIdDataset(XedDb.DocSource(XedDocKind.CpuId));
                    DataFlow.EmitCpuIdDataset(cpuid);       
                },
                () => {
                    var chips = DataFlow.CalcChipMap(XedDb.DocSource(XedDocKind.ChipMap));
                    DataFlow.EmitChipMap(chips);
                    var forms = DataFlow.CalcFormImports(XedDb.DocSource(XedDocKind.FormData));
                    DataFlow.EmitFormImports(forms);
                    var inst = DataFlow.CalcChipInstructions(forms, chips);
                    DataFlow.EmitChipInstructions(inst);
                },
                () => {
                    var rules = DataFlow.CalcRuleBlocks(XedDb.DocSource(XedDocKind.RuleBlocks));
                    DataFlow.EmitRules(rules);
                },
                () => {
                    var widths = DataFlow.CalcWidths(XedDb.DocSource(XedDocKind.Widths));
                    DataFlow.EmitOpWidths(widths.OpWidths);
                    DataFlow.EmitPointerWidths(widths.PointerWidthDescriptions);
                }
            );
             
            
            //var dec = XedRuleSpecs.CalcTableCriteria(XedDb.RuleSource(RuleTableKind.DEC), status => Channel.Row(status));

            // var dec = XedRuleSpecs.criteria(RuleTableKind.DEC);
            // var rules = new XedRuleTables();
            // var buffers = new XedRuleBuffers();
            // buffers.Target.TryAdd(RuleTableKind.ENC, enc);
            // buffers.Target.TryAdd(RuleTableKind.DEC, dec);
            // var rt = XedRules.tables(buffers);


        }
    }
}