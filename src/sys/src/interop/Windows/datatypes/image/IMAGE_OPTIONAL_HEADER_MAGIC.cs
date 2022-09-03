//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    public enum IMAGE_OPTIONAL_HEADER_MAGIC : uint
    {
        IMAGE_NT_OPTIONAL_HDR_MAGIC = 523u,
        IMAGE_NT_OPTIONAL_HDR32_MAGIC = 267u,
        IMAGE_NT_OPTIONAL_HDR64_MAGIC = 523u,
        IMAGE_ROM_OPTIONAL_HDR_MAGIC = 263u
    }
}