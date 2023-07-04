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
            // using var src = MemoryFiles.map(path);
            // var stats = AsciLines.stats(src.Bytes, 400000);
            // //iter(stats, stat => Channel.Row(stat));
            // var lines = Lines.lines(src);
            // var count = lines.Length;
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var line = ref skip(lines,i);
            //     Channel.Row(line);
            // }

            var data = DataFlow.CalcInstDump(path);
            DataFlow.EmitInstDump(data);
        }

    }
}