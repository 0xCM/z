//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymKindRow
    {
        const string TableId = "symbol.kinds";

        /// <summary>
        /// The declaration order
        /// </summary>
        [Render(8)]
        public uint Index;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        [Render(12)]
        public ulong Value;

        /// <summary>
        /// The declaring type
        /// </summary>
        [Render(64)]
        public Identifier Type;

        /// <summary>
        /// The kind identifier
        /// </summary>
        [Render(1)]
        public Identifier Name;
    }
}