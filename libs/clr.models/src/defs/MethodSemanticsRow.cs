//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.MethodSemantics), StructLayout(LayoutKind.Sequential)]
        public struct MethodSemanticsRow
        {
            public MethodSemanticsAttributes Semantic;

            public CliRowKey Method;

            public CliRowKey Association;
        }
    }
}