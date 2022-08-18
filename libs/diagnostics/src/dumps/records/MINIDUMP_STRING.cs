//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_string
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MINIDUMP_STRING : IRecord<MINIDUMP_STRING>
        {
            /// <summary>
            /// The size of the string in the Buffer member, in bytes. This size does not include the null-terminating character.
            /// </summary>
            public uint Length;

            /// <summary>
            /// The null-terminated string.
            /// </summary>
            public char* Buffer;
        }
    }
}