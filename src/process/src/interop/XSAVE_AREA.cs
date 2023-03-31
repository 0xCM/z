//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public struct XSAVE_AREA
    {
        public XSAVE_FORMAT LegacyState;

        public XSAVE_AREA_HEADER Header;
    }
}