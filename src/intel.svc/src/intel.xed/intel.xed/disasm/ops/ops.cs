//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static uint ops(in DisasmBlock src, Span<OpSpec> dst)
        {
            var count = src.OpCount;
            for(var k=0; k<count; k++)
                parse(skip(src.Ops, k).Content, out seek(dst,k)).Require();
            return count;
        }

        public static Index<OpSpec> ops(in DisasmBlock src)
        {
            var count = src.OpCount;
            var dst = alloc<OpSpec>(count);
            ops(src,dst);
            return dst;
        }
    }
}