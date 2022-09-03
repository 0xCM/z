//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_NT_HEADERS32
    {
        public uint Signature;

        public CoffHeader FileHeader;

        public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
    }
}