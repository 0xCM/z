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
        public enum SegDefaultKind : byte
        {
            [Symbol("default_ds", "DEFAULT_SEG=0")]
            DefaultDS = 0,

            [Symbol("default_ss", "DEFAULT_SEG=1")]
            DefaultSS = 1,

            [Symbol("default_es","DEFAULT_SEG=2")]
            DefaultES = 2
        }
    }
}