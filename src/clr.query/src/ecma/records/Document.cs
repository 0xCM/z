//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct Document : IEcmaRecord<Document>
        {
            const string TableId = "documents";

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