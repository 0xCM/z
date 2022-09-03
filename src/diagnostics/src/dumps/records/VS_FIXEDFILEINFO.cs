//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/verrsrc/ns-verrsrc-vs_fixedfileinfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential), DocRef("sdk-api-src/content/verrsrc/ns-verrsrc-vs_fixedfileinfo.md")]
        public struct VS_FIXEDFILEINFO
        {
            public uint dwSignature;

            public uint dwStrucVersion;

            public uint dwFileVersionMS;

            public uint dwFileVersionLS;

            public uint dwProductVersionMS;

            public uint dwProductVersionLS;

            public uint dwFileFlagsMask;

            public uint dwFileFlags;

            public uint dwFileOS;

            public uint dwFileType;

            public uint dwFileSubtype;

            public uint dwFileDateMS;

            public uint dwFileDateLS;
        }
    }
}