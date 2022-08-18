//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitSeq4;

    using L = CreditModel.ContentLevel;

    partial class CreditModel
    {
        /// <summary>
        /// Defines literals that isolate content reference components
        /// </summary>
        [DataWidth(16)]
        public enum ContentField : ushort
        {
            /// <summary>
            /// Defines the (uniform) bitfield segment width
            /// </summary>
            [BinaryLiteral("[1111]")]
            SegWidth = b1111,

            /// <summary>
            /// Defines the L0 bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00001111]")]
            L0 = SegWidth << L.L0,

            /// <summary>
            /// Defines the L1 bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 11110000]")]
            L1 = SegWidth << L.L1,

            /// <summary>
            /// Defines the L2 bitfield segment
            /// </summary>
            [BinaryLiteral("[00001111 00000000]")]
            L2 = SegWidth << L.L2,

            /// <summary>
            /// Defines the Type bitfield segment
            /// </summary>
            [BinaryLiteral("[11110000 00000000]")]
            Type = SegWidth << L.Type,
        }
    }
}