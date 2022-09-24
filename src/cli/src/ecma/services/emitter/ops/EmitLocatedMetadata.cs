//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitLocatedMetadata(Assembly src, uint bpl, FilePath dst)
        {
            try
            {
                var flow = EmittingFile(dst);
                ByteSize size = MemoryEmitter.emit(Clr.metadata(src), bpl, dst);
                EmittedBytes(flow, size);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

        public void EmitLocatedMetadata(IApiPack dst, uint bpl = 64)
            => iter(ApiMd.Parts, c => EmitLocatedMetadata(c, bpl, dst.Metadata(EcmaSections.ApiHex).Path(c.GetSimpleName(), FileKind.LocatedHex)), true);
    }
}