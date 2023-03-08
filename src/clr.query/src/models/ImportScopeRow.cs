//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImportScopeRow
    {
        [Render(12)]
        public EcmaBlobIndex Imports;
    }
    
}