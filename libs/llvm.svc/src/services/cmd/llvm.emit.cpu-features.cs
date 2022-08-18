//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/cpu-features")]
        void EmitCpuFeatures()
        {
            var src = DataProvider.Entities(e => e.IsProcessor()).Select(e => e.ToProcessor());
            var count = src.Count;
            var dst = list<CpuFeature>();
            var counter = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var processor = ref src[i];
                var features = processor.Features;
                var fcount = features.Count;
                for(var j=0; j<fcount; j++)
                {
                    var feature = new CpuFeature();
                    feature.Seq = counter++;
                    feature.Processor = processor.Name;
                    feature.FeatureName = features[j];
                    dst.Add(feature);
                }
            }

            Query.TableEmit("llvm.cpu.features", dst.ViewDeposited());
        }
    }
}
