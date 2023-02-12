//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed), DataWidth(num3.Width)]
        public enum SegPrefixKind : byte
        {
            [Symbol("no_seg_prefix", "SEG_OVD=0")]
            None = 0,

            [Symbol("cs_prefix", "SEG_OVD=1")]
            CS = 1,

            [Symbol("ds_prefix", "SEG_OVD=2")]
            DS = 2,

            [Symbol("es_prefix", "SEG_OVD=3")]
            ES = 3,

            [Symbol("fs_prefix", "SEG_OVD=4")]
            FS = 4,

            [Symbol("gs_prefix", "SEG_OVD=5")]
            GS = 5,

            [Symbol("ss_prefix", "SEG_OVD=6")]
            SS = 6
        }
    }
}