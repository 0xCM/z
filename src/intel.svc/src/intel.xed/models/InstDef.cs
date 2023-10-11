//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public struct InstDef : IComparable<InstDef>
    {
        public XedInstClass InstClass;

        public Index<InstPatternSpec> PatternSpecs;

        public int CompareTo(InstDef src)
        {
            var result = InstClass.CompareTo(src.InstClass);
            if(result == 0)
            {
                if(PatternSpecs.IsNonEmpty && src.PatternSpecs.IsNonEmpty)
                    result = PatternSpecs.First.OpCode.CompareTo(src.PatternSpecs.First.OpCode);
            }
            return result;
        }
    }
}
