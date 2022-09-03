//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential, Pack=4)]
        public struct MINIDUMP_MODULE : IRecord<MINIDUMP_MODULE>
        {
            public ulong BaseOfImage;

            public uint SizeOfImage;

            public uint CheckSum;

            public uint TimeDateStamp;

            public uint ModuleNameRva;

            public VS_FIXEDFILEINFO VersionInfo;

            public MINIDUMP_LOCATION_DESCRIPTOR CvRecord;

            public MINIDUMP_LOCATION_DESCRIPTOR MiscRecord;

            public ulong Reserved0;

            public ulong Reserved1;
        }
    }
}