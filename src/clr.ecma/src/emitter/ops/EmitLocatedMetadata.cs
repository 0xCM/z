//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitLocatedMetadata(ReadOnlySeq<Assembly> src, IDbArchive dst, uint bpl = 64)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var a = ref src[i];
                EmitLocatedMetadata(a, bpl, dst.Path(a.GetSimpleName(), FileKind.LocatedHex));
            }
        }

        public void EmitLocatedMetadata(IApiPack dst, uint bpl = 64)
            => iter(ApiMd.Parts, c => EmitLocatedMetadata(c, bpl, dst.Metadata(EcmaSections.ApiHex).Path(c.GetSimpleName(), FileKind.LocatedHex)), true);

        public void EmitLocatedMetadata(Assembly src, uint bpl, FilePath dst)
        {
            try
            {
                var flow = EmittingFile(dst);
                ByteSize size = MemoryEmitter.emit(ClrAssembly.metadata(src), bpl, dst);
                EmittedBytes(flow, size);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }
    }
}