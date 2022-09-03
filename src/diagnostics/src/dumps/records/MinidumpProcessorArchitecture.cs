//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        public enum MinidumpProcessorArchitecture : ushort
        {
            Intel = 0,

            Mips = 1,

            Alpha = 2,

            Ppc = 3,

            Shx = 4,

            Arm = 5,

            Ia64 = 6,

            Alpha64 = 7,

            Msil = 8,

            Amd64 = 9,

            Ia32OnWin64 = 10,

            Arm64 = 12,

            Unknown = 0xffff,
        }
    }
}