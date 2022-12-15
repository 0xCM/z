//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(EcmaTableKind.FieldLayout), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct FieldLayout : IEcmaRecord<FieldLayout>
        {
            public uint Offset;

            public EcmaRowKey Field;
        }
    }
}