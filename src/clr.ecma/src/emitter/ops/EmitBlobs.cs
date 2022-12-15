//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitBlobs(IDbArchive dst)
            => iter(ApiAssemblies.Parts, c => EmitBlobs(c, dst.Metadata(EcmaSections.Blobs).PrefixedTable<EcmaBlobInfo>(c.GetSimpleName())), true);

        public void EmitBlobs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(ApiAssemblies.Parts, c => EmitBlobs(c, dst.PrefixedTable<EcmaBlobInfo>(c.GetSimpleName())), PllExec);

        public void EmitBlobs(Assembly src, FilePath dst)
            => TableEmit(EcmaReader.create(src).ReadBlobRows(), dst);
    }
}