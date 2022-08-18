//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.RuleCellKind;

    partial class XedRules
    {
        /// <summary>
        /// Classifies a <see cref='LayoutCell'/>
        /// </summary>
        public enum LayoutCellKind : byte
        {
            [Symbol("", "The tragic unknown")]
            None,

            /// <summary>
            ///  Specifies a <see cref='K.BitLit'/> kind
            /// </summary>
            [Symbol("BL", "Specifies a Bit literal")]
            BL = K.BitLit,

            /// <summary>
            ///  Specifies a <see cref='K.HexLit'/> kind
            /// </summary>
            [Symbol("XL", "Specifies a Hex literal")]
            XL = K.HexLit,

            /// <summary>
            ///  Specifies a <see cref='K.SegVar'/> kind
            /// </summary>
            [Symbol("SV", "Specifies a SegVar")]
            SV = K.SegVar,

            /// <summary>
            ///  Specifies a <see cref='K.FieldSeg'/> kind
            /// </summary>
            [Symbol("FS", "Specifies a FieldSeg")]
            FS = K.FieldSeg,

            /// <summary>
            ///  Specifies a <see cref='K.NtCall'/> kind
            /// </summary>
            [Symbol("NT", "Specifies a NontermCall")]
            NT = K.NtCall,

            /// <summary>
            ///  Specifies a <see cref='K.WidthVar'/> kind
            /// </summary>
            [Symbol("WV", "Specifies a width variable")]
            WV = K.WidthVar,
        }
    }
}