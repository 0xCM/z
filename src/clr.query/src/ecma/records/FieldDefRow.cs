//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {     
        [EcmaRow(TableIndex.Field), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct FieldDefRow : IEcmaRow<FieldDefRow>
        {
            [Render(12)]
            public EcmaStringKey Name;

            [Render(12)]
            public EcmaBlobKey Sig;

            [Render(12)]
            public Address32 Offset;

            [Render(12)]
            public EcmaBlobKey Marshal;

            [Render(1)]
            public FieldAttributes Attributes;
        }
    }
}