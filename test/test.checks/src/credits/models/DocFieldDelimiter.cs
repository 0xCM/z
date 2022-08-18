//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CreditModel
    {
        /// <summary>
        /// Defines document field parts
        /// </summary>
        public enum DocFieldDelimiter : byte
        {
            /// <summary>
            /// The vendor component
            /// </summary>
            Vendor = 0,

            /// <summary>
            /// The volume component
            /// </summary>
            Volume = 8,

            /// <summary>
            /// The Division component
            /// </summary>
            Division = 16,

            /// <summary>
            /// The Chapter component
            /// </summary>
            Chapter = 16,

            /// <summary>
            /// The Appendix component
            /// </summary>
            Appendix = 16,

            /// <summary>
            /// The Section component
            /// </summary>
            Section = 24,

            /// <summary>
            /// The Topic component
            /// </summary>
            Topic = 32,

            /// <summary>
            /// The content reference component
            /// </summary>
            Content = 40
        }
    }
}