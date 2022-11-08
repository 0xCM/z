//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;

    partial class XedPatterns
    {
        public static void instruction(InstructionId id, string expr, InstFieldValues props, out Instruction dst)
            => dst = new Instruction(id, expr, props.InstClass, props.InstForm, props);

        public static Index<InstPatternRecord> records(Index<InstPattern> src, bool pll = true)
        {
            var count = src.Count;
            var dst = sys.bag<InstPatternRecord>();
            iter(src, p => dst.Add(record(p)), pll);
            var sorted = dst.Array().Sort(PatternSort.comparer());
            return sorted.Resequence();
        }

        static InstPatternRecord record(in InstPattern src)
        {
            ref readonly var body = ref src.Body;
            var dst = InstPatternRecord.Empty;
            dst.PatternId = src.PatternId;
            dst.OpCode = src.OpCode;
            dst.Mode = src.Mode;
            dst.Lock = src.Lock;
            dst.Scalable = src.Scalable;
            Require.invariant(src.InstClass.Kind != 0);
            dst.InstClass = classifier(src.InstClass);
            dst.InstForm = src.InstForm;
            dst.Body = body;
            return dst;
        }
    }
}