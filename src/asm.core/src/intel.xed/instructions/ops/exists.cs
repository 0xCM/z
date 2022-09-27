//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool exists(in OpAttribs src, OpAttribKind @class)
        {
            var result = false;
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref src[i];
                if(a.Class == @class)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool exists(ReadOnlySpan<PatternOp> src, OpAttribKind @class)
        {
            var result = false;
            for(var i=0; i<src.Length; i++)
            {
                result = exists(skip(src,i).Attribs, @class);
                if(result)
                    break;
            }
            return result;
        }
    }
}