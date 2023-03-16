//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.CustomAttribute), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct CustomAttribRow : IEcmaRecord<CustomAttribRow>
        {
            [Render(12)]
            public EcmaRowKey Parent;

            [Render(12)]
            public EcmaRowKey Constructor;

            [Render(12)]
            public EcmaBlobIndex Value;

            [Render(12)]
            public Address32 ValueOffset;
        }       
    }
}