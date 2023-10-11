//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using X = XedRegId;

partial class XedModels
{
    [SymSource("xed"), DataWidth(num9.Width)]
    public enum MmxRegId : ushort
    {
        MM0 = X.MMX0,

        MM1 = X.MMX1,

        MM2 = X.MMX2,

        MM3 = X.MMX3,

        MM4 = X.MMX4,

        MM5 = X.MMX5,

        MM6 = X.MMX6,

        MM7 = X.MMX7,
    }
}