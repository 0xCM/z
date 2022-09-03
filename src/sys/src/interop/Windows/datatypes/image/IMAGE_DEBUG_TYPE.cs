//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [SymSource(images), Flags]
    public enum IMAGE_DEBUG_TYPE : uint
    {
        IMAGE_DEBUG_TYPE_UNKNOWN = 0u,

        IMAGE_DEBUG_TYPE_COFF = 1u,

        IMAGE_DEBUG_TYPE_CODEVIEW = 2u,

        IMAGE_DEBUG_TYPE_FPO = 3u,

        IMAGE_DEBUG_TYPE_MISC = 4u,

        IMAGE_DEBUG_TYPE_EXCEPTION = 5u,

        IMAGE_DEBUG_TYPE_FIXUP = 6u,

        IMAGE_DEBUG_TYPE_BORLAND = 9u
    }
}