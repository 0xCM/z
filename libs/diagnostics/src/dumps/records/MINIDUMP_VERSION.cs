//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// #define MINIDUMP_VERSION   (42899)
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_VERSION : IRecord<MINIDUMP_VERSION>
        {
            public ushort Value;

            public ushort Expected => 42899;
        }
    }
}