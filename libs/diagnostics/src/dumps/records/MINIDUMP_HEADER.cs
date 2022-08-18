//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_header
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_HEADER : IRecord<MINIDUMP_HEADER>
        {
            /// <summary>
            /// Identifying leading bytes
            /// </summary>
            public MINIDUMP_SIGNATURE Signature;

            ushort _PrivateVersion;

            /// <summary>
            /// The version of the minidump format. The low-order word is <see cref='MINIDUMP_VERSION'/>. The high-order word is an internal value that is implementation specific.
            /// </summary>
            public MINIDUMP_VERSION Version;

            /// <summary>
            /// The number of streams in the minidump directory.
            /// </summary>
            public uint NumberOfStreams;

            /// <summary>
            /// The base RVA of the minidump directory which is an array of <see cref='MINIDUMP_DIRECTORY'/> structures.
            /// </summary>
            public uint StreamDirectoryRva;

            /// <summary>
            /// The checksum for the minidump file. This member can be zero.
            /// </summary>
            public uint CheckSum;

            /// <summary>
            /// Time and date, an integral value specifying the number of seconds (not counting leap seconds) since 00:00, Jan 1 1970 UTC, corresponding to POSIX time.
            /// </summary>
            public uint TimeDateStamp;

            /// <summary>
            /// One or more values from the MINIDUMP_TYPE enumeration type.
            /// </summary>
            public MinidumpType Flags;
        }
    }
}