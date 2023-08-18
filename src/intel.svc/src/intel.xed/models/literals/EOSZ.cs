//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(3,8)]
    public enum EOSZ : sbyte
    {
        [Symbol("8", "EOSZ=0")]
        EOSZ8 = 0,

        [Symbol("16", "EOSZ=1")]
        EOSZ16 = 1,

        [Symbol("32", "EOSZ=2")]
        EOSZ32 = 2,

        [Symbol("64", "EOSZ=3")]
        EOSZ64 = 3,
    }
}
