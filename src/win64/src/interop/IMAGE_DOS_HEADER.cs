//-----------------------------------------------------------------------------
// Copyright   :  None
// License     :  Any, except GPL or variants thereof
//-----------------------------------------------------------------------------
namespace Windows
{
    /// <summary>
    /// From winnt.h
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
	public record struct IMAGE_DOS_HEADER
	{
		public const ushort MAGIC = 0x5A4D;

        /// <summary>
        /// Magic number
        /// </summary>
		public ushort e_magic;
		
        /// <summary>
        /// Bytes on last page of file
        /// </summary>
        public ushort e_cblp;
		
        /// <summary>
        /// Pages in file
        /// </summary>
        public ushort e_cp;

        /// <summary>
        /// Relocations
        /// </summary>
		public ushort e_crlc;
		
        /// <summary>
        /// Size of header in paragraphs
        /// </summary>
        public ushort e_cparhdr;
		
        /// <summary>
        /// Minimum extra paragraphs needed
        /// </summary>
        public ushort e_minalloc;

        /// <summary>
        /// Maximum extra paragraphs needed
        /// </summary>
		public ushort e_maxalloc;

        /// <summary>
        /// Initial (relative) SS value
        /// </summary>
		public ushort e_ss;
		
        /// <summary>
        /// Initial SP value
        /// </summary>
        public ushort e_sp;
		
        public ushort e_csum; // Checksum
		
        public ushort e_ip; // Initial IP value
		
        public ushort e_cs; // Initial (relative) CS value
		
        public ushort e_lfarlc; // File address of relocation table
		
        public ushort e_ovno; // Overlay number

        /// <summary>
        /// Reserved words
        /// </summary>
		public ulong e_res;

        /// <summary>
        /// OEM identifier (for e_oeminfo)
        /// </summary>
		public ushort e_oemid;

        /// <summary>
        /// OEM information; e_oemid specific
        /// </summary>
		public ushort e_oeminfo;

        /// <summary>
        /// Reserved words
        /// </summary>
		public ulong e_res2_0;

        /// <summary>
        /// Reserved words
        /// </summary>
		public ulong e_res2_1;

        /// <summary>
        /// Reserved words
        /// </summary>
		public uint e_res2_2;

        /// <summary>
        /// File address of new exe header
        /// </summary>
		public uint e_lfanew;
	}    
}