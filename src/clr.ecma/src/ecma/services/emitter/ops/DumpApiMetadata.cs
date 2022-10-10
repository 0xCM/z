//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaEmitter
    {
        public void EmitApiMetadump(IApiPack dst)
            => EmitApiMetadump(dst.Metadata("metadump"));

        public void EmitApiMetadump(IDbArchive dst)
            => EmitMetadump(ApiMd.Parts, dst);
    }
}