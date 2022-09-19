//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
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

        public static Detail detail(ProjectContext context, in FileRef src)
            => detail(context, XedDisasm.datafile(context, src));

        public static Detail detail(ProjectContext context, in DataFile src)
            => detail(XedDisasm.summary(context,src));

    }
}