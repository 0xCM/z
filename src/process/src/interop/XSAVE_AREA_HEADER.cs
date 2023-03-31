//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack = 8)]
    public unsafe struct XSAVE_AREA_HEADER 
    {
        public Hex64 Mask;
        
        public Hex64 CompactionMask;
        
        public fixed ulong Reserved2[6];
    }
}