//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.CustomAttribute), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct CustomAttribRow : IEcmaRow<CustomAttribRow>
        {
            [Render(12)]
            public EcmaToken Parent;

            [Render(12)]
            public EcmaToken Constructor;

            [Render(12)]
            public EcmaBlobKey Value;

            [Render(12)]
            public Address32 ValueOffset;
        }       
    }
}