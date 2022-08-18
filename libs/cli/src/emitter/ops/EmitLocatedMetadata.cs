//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class CliEmitter
    {
        public void EmitLocatedMetadata(Assembly src, uint bpl, FS.FilePath dst)
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
            => iter(ApiMd.Assemblies, c => EmitLocatedMetadata(c, bpl, dst.Metadata(CliSections.ApiHex).Path(c.GetSimpleName(), FileKind.LocatedHex)), true);
    }
}