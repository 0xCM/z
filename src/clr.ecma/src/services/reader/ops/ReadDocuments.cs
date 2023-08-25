//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class EcmaReader
    {
        public ParallelQuery<EcmaDocInfo> ReadDocInfo()
            => from handle in MD.Documents.AsParallel()
                select ReadDocInfo(handle);
                
        EcmaDocInfo ReadDocInfo(DocumentHandle handle)
        {
            var src = MD.GetDocument(handle);
            var dst = new EcmaDocInfo();
            dst.Name = String(src.Name);
            dst.ContentHash = Blob(src.Hash);
            return dst;
        }
    }
}