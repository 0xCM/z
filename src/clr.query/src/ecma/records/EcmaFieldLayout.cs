//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaRecordDefs
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct FieldLayout
        {
            const string TableId = "ecma.field.layouts";

            public uint Offset;

            public EcmaRowKey Field;
        }
    }
}