//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// #define MINIDUMP_SIGNATURE ('PMDM')
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_SIGNATURE : IRecord<MINIDUMP_SIGNATURE>
        {
            public uint Value;

            public uint Expected => (uint)'P' << 24 | (uint)'M' << 16 | (uint)'D' << 8 | (uint)'M';
        }
    }
}
