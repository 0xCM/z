//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.Document), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct DocumentRow : IEcmaRow<DocumentRow>
        {
            [Render(12)]
            public EcmaBlobKey Name;

            [Render(12)]
            public EcmaGuidKey HashAlgorithm;

            [Render(12)]
            public EcmaBlobKey Hash;

            [Render(12)]
            public EcmaGuidKey Language;
        }       
    }
}