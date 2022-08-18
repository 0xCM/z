//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_NT_HEADERS64
    {
        public uint Signature;

        public CoffHeader FileHeader;

        public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
    }
}