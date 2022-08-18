//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = CreditModel.DocFieldDelimiter;

    using static BitSeq8;

    partial class CreditModel
    {
        /// <summary>
        /// Defines literals that isolate reference components
        /// </summary>
        [DataWidth(47)]
        public enum DocField : ulong
        {
            /// <summary>
            /// Defines the (uniform) bitfield segment width
            /// </summary>
            [BinaryLiteral("[11111111]")]
            SegWidth = b11111111,

            /// <summary>
            /// Defines the Vendor bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 00000000 00000000 00000000 00000000 11111111]")]
            Vendor = SegWidth << P.Vendor,

            /// <summary>
            /// Defines the Volume bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 00000000 00000000 00000000 11111111 00000000]")]
            Volume = SegWidth << P.Volume,

            /// <summary>
            /// Defines the Division bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 00000000 00000000 11111111 00000000 00000000]")]
            Division = SegWidth << P.Division,

            /// <summary>
            /// Defines the Chapter bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 00000000 00000000 11111111 00000000 00000000]")]
            Chapter = Division,

            /// <summary>
            /// Defines the Appendix bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 00000000 00000000 11111111 00000000 00000000]")]
            Appendix = Division,

            /// <summary>
            /// Defines the Section bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 00000000 11111111 00000000 00000000 00000000]")]
            Section = SegWidth << P.Section,

            /// <summary>
            /// Defines the Topic bitfield segment
            /// </summary>
            [BinaryLiteral("[00000000 00000000 11111111 00000000 00000000 00000000 00000000]")]
            Topic = SegWidth << P.Topic,

            [BinaryLiteral("[11111111 11111111]")]
            ContentWidth = ushort.MaxValue,

            /// <summary>
            /// Defines the Content bitfield segment
            /// </summary>
            [BinaryLiteral("[11111111 11111111 00000000 00000000 00000000 00000000 00000000]")]
            Content = ContentWidth << P.Content,
        }
    }
}