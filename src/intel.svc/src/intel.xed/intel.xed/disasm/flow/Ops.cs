//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasmModels;

    partial class XedDisasm
    {
        [MethodImpl(Inline), Op]
        public static IContextBuffer buffer(ProjectContext context, in FileRef src)
            => new ContextBuffer(src);

        [MethodImpl(Inline)]
        public static IFlow flow(ProjectContext context)
            => new Flow(context);

        static long DisasmTokens;

        [MethodImpl(Inline)]
        public static DisasmToken token()
            => (uint)core.inc(ref DisasmTokens);

        public static DisasmDetail detail(ProjectContext context, in FileRef src)
            => detail(context, datafile(context, src));

        public static DisasmDetail detail(ProjectContext context, in DisasmDataFile src)
            => detail(summary(context,src));
    }
}