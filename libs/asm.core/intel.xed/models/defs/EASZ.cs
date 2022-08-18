//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(3,8)]
        public enum EASZ : sbyte
        {
            [Symbol("")]
            None = 0,

            [Symbol("16", "EASZ=1")]
            EASZ16 = 1,

            [Symbol("32", "EASZ=2")]
            EASZ32 = 2,

            [Symbol("64", "EASZ=3")]
            EASZ64 = 3,

            [Symbol("32/64", "EASZ!=1")]
            EASZNot16 = 4,
        }
    }
}