//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed), DataWidth(num2.Width)]
        public enum LLRC : byte
        {
            [Symbol("0", "LLRC=0")]
            LLRC0=0,

            [Symbol("1", "LLRC=1")]
            LLRC1=1,

            [Symbol("2", "LLRC=2")]
            LLRC2=2,

            [Symbol("3", "LLRC=3")]
            LLRC3=3
        }
    }
}