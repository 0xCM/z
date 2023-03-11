//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.Document), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct Document : IEcmaRecord<Document>
        {
            [Render(12)]
            public EcmaBlobIndex Name;

            [Render(12)]
            public GuidIndex HashAlgorithm;

            [Render(12)]
            public EcmaBlobIndex Hash;

            [Render(12)]
            public GuidIndex Language;
        }       
    }
}