//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.FieldLayout), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct FieldLayoutRow : IEcmaRow<FieldLayoutRow>
        {
            public uint Offset;

            public EcmaRowKey Field;
        }
    }
}