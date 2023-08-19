//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public partial class Xed
    {
        [MethodImpl(Inline)]
        public static OpWidthDetail describe(WidthCode code)
            => code == 0 ? OpWidthDetail.Empty : XedOps.WidthLookup[code];
    }
}