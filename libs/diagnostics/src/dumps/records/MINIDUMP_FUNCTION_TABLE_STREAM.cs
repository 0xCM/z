//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_function_table_stream
        /// </summary>
        /// <remarks>
        /// In this context, a data stream is a set of data in a minidump file. This header structure is followed by NumberOfDescriptors
        /// function tables. For each function table there is a MINIDUMP_FUNCTION_TABLE_DESCRIPTOR structure, then the raw system descriptor
        /// for the table, then the raw system function entry data. If necessary, alignment padding is placed between tables to properly
        /// align the initial structures.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_FUNCTION_TABLE_STREAM : IRecord<MINIDUMP_FUNCTION_TABLE_STREAM>
        {
            /// <summary>
            /// The size of header information for the stream, in bytes. This value is sizeof(MINIDUMP_FUNCTION_TABLE_STREAM).
            /// </summary>
            public uint SizeOfHeader;

            /// <summary>
            /// The size of a descriptor in the stream, in bytes. This value is sizeof(MINIDUMP_FUNCTION_TABLE_DESCRIPTOR).
            /// </summary>
            public uint SizeOfDescriptor;

            /// <summary>
            /// The size of a raw system descriptor in the stream, in bytes. This value depends on the particular platform and system version on which the minidump was generated.
            /// </summary>
            public uint SizeOfNativeDescriptor;

            /// <summary>
            /// The size of a raw system function table entry, in bytes. This value depends on the particular platform and system version on which the minidump was generated.
            /// </summary>
            public uint SizeOfFunctionEntry;

            /// <summary>
            /// The number of descriptors in the stream.
            /// </summary>
            public uint NumberOfDescriptors;

            /// <summary>
            /// The size of alignment padding that follows the header, in bytes.
            /// </summary>
            public uint SizeOfAlignPad;
        }
    }
}