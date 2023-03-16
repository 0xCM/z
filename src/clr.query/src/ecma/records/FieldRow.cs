//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {     
        [Table(TableIndex.Field), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct FieldRow : IEcmaRecord<FieldRow>
        {
            [Render(12)]
            public EcmaStringIndex Name;

            [Render(12)]
            public EcmaBlobIndex Sig;

            [Render(12)]
            public Address32 Offset;

            [Render(12)]
            public EcmaBlobIndex Marshal;

            [Render(1)]
            public FieldAttributes Attributes;
        }
    }
}