//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CliRecord(CliTableKind.ImportScope), StructLayout(LayoutKind.Sequential)]
    public struct ImportScopeRow
    {
        [Render(12)]
        public CliBlobIndex Imports;
    }
    
}