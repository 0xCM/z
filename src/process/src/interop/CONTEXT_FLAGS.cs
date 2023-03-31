//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum CONTEXT_FLAGS : uint
    {
        CONTEXT_AMD64 = 0x00100000,

        CONTEXT_CONTROL = CONTEXT_AMD64 | 0x00000001,

        CONTEXT_INTEGER = CONTEXT_AMD64 | 0x00000002,
        
        CONTEXT_SEGMENTS = CONTEXT_AMD64 | 0x00000004,
        
        CONTEXT_FLOATING_POINT = CONTEXT_AMD64 | 0x00000008,
        
        CONTEXT_DEBUG_REGISTERS = CONTEXT_AMD64 | 0x00000010,

        CONTEXT_FULL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_FLOATING_POINT,

        CONTEXT_ALL = CONTEXT_CONTROL | CONTEXT_INTEGER |  CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS,
    
        CONTEXT_XSTATE = CONTEXT_AMD64 | 0x00000040,

        CONTEXT_KERNEL_CET = CONTEXT_AMD64 | 0x00000080,
    }
}