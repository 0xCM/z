//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitBlobs(IApiPack dst)
            => iter(ApiMd.Parts, c => EmitBlobs(c, dst.Metadata(EcmaSections.Blobs).PrefixedTable<CliBlob>(c.GetSimpleName())), true);

        public void EmitBlobs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(ApiMd.Parts, c => EmitBlobs(c, dst.PrefixedTable<CliBlob>(c.GetSimpleName())), true);

        public void EmitBlobs(Assembly src, FilePath dst)
        {
            var reader = EcmaReader.create(src);
            TableEmit(reader.ReadBlobs(), dst);
        }       
    }
}