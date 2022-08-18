//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// The directory entries make up the rows of a table. Each resource directory entry has the following format.
    /// Whether the entry is a Name or ID entry is indicated by the resource directory table,
    /// which indicates how many Name and ID entries follow it (remember that all the Name entries precede all the
    /// ID entries for the table). All entries for the table are sorted in ascending order: the Name entries by
    /// case-sensitive string and the ID entries by numeric value. Offsets are relative to the address in the
    /// IMAGE_DIRECTORY_ENTRY_RESOURCE DataDirectory
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct PeResource
    {
        public const string TableId = "image.resdir.entry";

        /// <summary>
        /// The offset of a string that gives the Type, Name, or Language ID entry, depending on level of table.
        /// </summary>
        public uint NameOffset;

        /// <summary>
        /// A 32-bit integer that identifies the Type, Name, or Language ID entry.
        /// </summary>
        public uint Id;

        /// <summary>
        /// High bit 0. Address of a Resource Data entry (a leaf).
        /// </summary>
        public uint DataEntryOffset;

        /// <summary>
        /// High bit 1. The lower 31 bits are the address of another resource directory table (the next level down).
        /// </summary>
        public uint SubdirectoryOffset;
    }
}