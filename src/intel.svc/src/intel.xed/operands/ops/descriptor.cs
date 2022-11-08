//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public partial class XedOps
    {
        [MethodImpl(Inline)]
        public static OpWidthRecord describe(OpWidthCode code)
            => code == 0 ? OpWidthRecord.Empty : XedOps.WidthLookup[code];
    }
}