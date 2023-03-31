//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XSTATE_CONTEXT
    {
        public Hex64 Mask;

        public Hex32 Length;

        public Hex32 Reserved1;

        public XSAVE_AREA* Area;

        public void* Buffer;

    }
}