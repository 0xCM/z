//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_DATA_DIRECTORY
    {
        public uint VirtualAddress;

        public uint Size;
    }
}