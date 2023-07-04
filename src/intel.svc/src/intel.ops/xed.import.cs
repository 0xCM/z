//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedRules;

    partial class XedCmd
    {
        [CmdOp("xed/import")]
        void RunImport()
            => XedRuntime.XedImport.Run();

        
        [CmdOp("xed/import/cpuid")]
        void ImportCpuId()
        {
            var source = XedDb.DocSource(XedDocKind.CpuId);
            var dataset = DataFlow.CalcCpuIdDataset(source);
            DataFlow.EmitCpuIdDataset(dataset);           
        }

        [CmdOp("xed/import/chipmap")]
        void ImportChipMap()
        {
            var src = XedDb.DocSource(XedDocKind.ChipMap);
            var chips = DataFlow.CalcChipMap(src);
            DataFlow.EmitChipMap(chips);
        }

        [CmdOp("xed/import/instdump")]
        void ImportInstDump()
        {
            var path = XedDb.DocSource(XedDocKind.RuleDump);
            var data = DataFlow.CalcInstDump(path);
            DataFlow.EmitInstDump(data);
        }

        [CmdOp("xed/import/widths")]
        void ImportWidths()
        {
            var path = XedDb.DocSource(XedDocKind.Widths);
            var data = DataFlow.CalcOpWidths(path);
            DataFlow.EmitOpWidths(data.OpWidths);
            DataFlow.EmitPointerWidths(data.PointerWidthDescriptions);
        }

        [CmdOp("xed/import/forms")]
        void ImportInstForms()
        {
            var path = XedDb.DocSource(XedDocKind.FormData);
            var data = DataFlow.CalcFormImports(path);
            DataFlow.EmitFormImports(data);
        }

    }
}