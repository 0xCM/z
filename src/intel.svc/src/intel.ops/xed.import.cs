//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedRules;
    using static XedModels;
    partial class XedCmd
    {
        [CmdOp("xed/import")]
        void RunImport()
        {
            var cpuid = DataFlow.CalcCpuIdDataset(XedDb.DocSource(XedDocKind.CpuId));
            DataFlow.EmitCpuIdDataset(cpuid);       
            var codes = Symbols.symkinds<ChipCode>();  
            DataFlow.EmitChipCodes(codes);
            
            var chips = DataFlow.CalcChipMap(XedDb.DocSource(XedDocKind.ChipMap));
            DataFlow.EmitChipMap(chips);
            var dump = DataFlow.CalcInstDump(XedDb.DocSource(XedDocKind.RuleDump));
            DataFlow.EmitInstDump(dump);
            var widths = DataFlow.CalcWidths(XedDb.DocSource(XedDocKind.Widths));
            DataFlow.EmitOpWidths(widths.OpWidths);
            DataFlow.EmitPointerWidths(widths.PointerWidthDescriptions);
            var forms = DataFlow.CalcFormImports(XedDb.DocSource(XedDocKind.FormData));
            DataFlow.EmitFormImports(forms);
            var inst = DataFlow.CalcChipInstructions(forms, chips);
            DataFlow.EmitChipInstructions(inst);
            var bcastkinds = Symbols.kinds<BCastKind>();
            var broadacasts = Xed.broadcasts(bcastkinds);
            DataFlow.EmitBroadcastDefs(broadacasts);

            var dec = XedRuleSpecs.CalcTableCriteria(XedDb.RuleSource(RuleTableKind.DEC), status => Channel.Row(status));

            // var dec = XedRuleSpecs.criteria(RuleTableKind.DEC);
            // var rules = new XedRuleTables();
            // var buffers = new XedRuleBuffers();
            // buffers.Target.TryAdd(RuleTableKind.ENC, enc);
            // buffers.Target.TryAdd(RuleTableKind.DEC, dec);
            // var rt = XedRules.tables(buffers);


        }
    }
}