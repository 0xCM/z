//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.Document), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct DocumentRow : IEcmaRecord<DocumentRow>
        {
            [Render(12)]
            public EcmaBlobIndex Name;

            [Render(12)]
            public EcmaGuidIndex HashAlgorithm;

            [Render(12)]
            public EcmaBlobIndex Hash;

            [Render(12)]
            public EcmaGuidIndex Language;
        }       
    }
}