//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = AsmColWidths;

    /// <summary>
    /// Defines an IP location with context
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ProcessAsmRef
    {
        public const string TableId = "asm.global.ref";

        public const byte FieldCount = 5;

        /// <summary>
        /// A 0-based monotonic value that serves as a surrogate key
        /// </summary>
        [Render(W.Seq)]
        public uint Sequence;

        /// <summary>
        /// A 0-based 32-bit offset
        /// </summary>
        [Render(W.OffsetAddress)]
        public Address32 GlobalOffset;

        /// <summary>
        /// The IP block address
        /// </summary>
        [Render(W.BlockAddress)]
        public MemoryAddress BlockAddress;

        /// <summary>
        /// The IP address
        /// </summary>
        [Render(W.IP)]
        public MemoryAddress IP;

        /// <summary>
        /// The block-relative IP offset
        /// </summary>
        [Render(W.OffsetAddress)]
        public Address16 BlockOffset;
    }
}