//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;


    public struct MetadataDocInfo
    {   
        public string Name;

        public BinaryCode ContentHash;
    }

    partial class EcmaReader
    {
        public MetadataDocInfo ReadDocInfo(DocumentHandle handle)
        {
            var src = MD.GetDocument(handle);
            var dst = new MetadataDocInfo();
            dst.Name = String(src.Name);
            dst.ContentHash = ReadBlobData(src.Hash);
            return dst;
        }

        public ReadOnlySeq<MetadataDocInfo> ReadDocInfo()
            => DocHandles().Map(ReadDocInfo);
    }
}