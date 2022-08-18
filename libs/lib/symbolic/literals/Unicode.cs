//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum Unicode : ushort
    {
        Null = 0,

        /// <summary>
        /// Character Tabulation
        /// </summary>
        Tab = 9,

        /// <summary>
        /// Line Feed
        /// </summary>
        LF = 10,

        /// <summary>
        /// Line Tabulation
        /// </summary>
        VTab = 11,

        /// <summary>
        /// Form Feed
        /// </summary>
        FF = 12,

        /// <summary>
        /// Form Feed
        /// </summary>
        CR = 13,

        Space = 32,

        NextLine = 133,

        NoBreakSpace = 160,
    }
}