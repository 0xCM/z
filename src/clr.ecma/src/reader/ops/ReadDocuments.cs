//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public EcmaDocInfo ReadDocInfo(DocumentHandle handle)
        {
            var src = MD.GetDocument(handle);
            var dst = new EcmaDocInfo();
            dst.Name = String(src.Name);
            dst.ContentHash = ReadBlobData(src.Hash);
            return dst;
        }

        public ReadOnlySeq<EcmaDocInfo> ReadDocInfo()
            => DocHandles().Map(ReadDocInfo);
    }
}