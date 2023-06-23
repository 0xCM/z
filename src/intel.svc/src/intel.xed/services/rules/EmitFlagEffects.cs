//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void EmitFlagEffects(Index<InstPattern> src)
        {
            const string RenderPattern = "{0,-16} | {1,-4} | {2, -4}";
            var path = XedPaths.RuleTarget("flags", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            writer.AppendLineFormat(RenderPattern, "Instruction",  "F", "E");
            var counter = 0u;

            for(var j=0; j<src.Count; j++)
            {
                ref readonly var pattern = ref src[j];
                ref readonly var effects = ref pattern.Effects;
                for(var k=0; k<effects.Count; k++)
                {
                    ref readonly var e = ref effects[k];
                    writer.AppendLineFormat(RenderPattern,
                        XedRender.format(pattern.InstClass),
                        e.Flag.ToString().ToLower(),
                        XedRender.format(e.Effect)
                        );
                    counter++;
                }
            }

            EmittedFile(emitting,counter);
        }
    }
}