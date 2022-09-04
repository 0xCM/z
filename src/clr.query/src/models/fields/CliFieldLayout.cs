//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CliRecord(CliTableKind.FieldLayout), StructLayout(LayoutKind.Sequential)]
    public struct CliFieldLayout
    {
        public uint Offset;

        public CliRowKey Field;
    }
}