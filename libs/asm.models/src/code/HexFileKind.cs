//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// 0x57 0x56 0x55 0x53 0x48 0x83 0xec 0x28 0x33
    /// </summary>
    public enum HexFileKind : byte
    {
        None,

        /// <summary>
        /// Identifies a hex file that contains line-delimited segments with uniformly space-delimited hex bytes
        /// </summary>
        /// <example>
        /// 0x57 0x56 0x55 0x53 0x48 0x83 0xec 0x28 0x33
        /// 0x41 0x57 0x41 0x56 0x41 0x55 0x41 0x54
        /// </example>
        SpacedLines8,

        /// <summary>
        /// Identifies a hex file that contains line-delimited segments with uniformly space-delimited hex words
        /// </summary>
        SpacedLines16,

        /// <summary>
        /// Identifies a hex file that contains line-delimited segments with uniformly space-delimited hex double-words
        /// </summary>
        SpacedLines32,

        /// <summary>
        /// Identifies a hex file that contains line-delimited segments with uniformly space-delimited hex quad-words
        /// </summary>
        SpacedLines64,

        /// <summary>
        /// Identifies a csv file where each line specifies a segment address together with memory content based at that address
        /// </summary>
        CsvMem,

        /// <summary>
        /// Identifies a text file where each line is of the form x{0:x}[{1:D5}:{2:D5}]=<{3}>
        /// </summary>
        HexPack,
    }
}