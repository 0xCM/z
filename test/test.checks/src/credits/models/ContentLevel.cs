//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CreditModel
    {
        /// <summary>
        /// Defines level hierarchy component values
        /// </summary>
        public enum ContentLevel : byte
        {
            /// <summary>
            /// type: [a].b.c
            /// </summary>
            L0 = 0,

            /// <summary>
            /// type: a.[b].c
            /// </summary>
            L1 = 4,

            /// <summary>
            /// type: a.b.[c]
            /// </summary>
            L2 = 8,

            /// <summary>
            /// [type]: a.b.c
            /// </summary>
            Type = 12
        }
    }
}