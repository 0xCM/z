//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public ExecToken EmitMetadump(FilePath src, FilePath dst)
        {
            var token = ExecToken.Empty;
            try
            {
                if(ClrModules.valid(src))
                {
                    var flow = EmittingFile(dst);
                    using var stream = File.OpenRead(src.Name);
                    using var pe = ImageMemory.pe(stream);
                    using var target = dst.Writer();
                    MsilCodeModels.mdv(pe.GetMetadataReader(), target).Visualize();
                    token = Emitter.EmittedFile(flow);
                }
            }
            catch(BadImageFormatException bfe)
            {
                Error(bfe);
            }
            catch(Exception e)
            {
                Error(e);
            }
            return token;
        }

        public void EmitApiMetadump(IApiPack dst)
            => EmitApiMetadump(dst.Metadata("metadump"));

        public void EmitMetadump(ReadOnlySeq<Assembly> src, IDbArchive dst, bool clear = true)
        {
            if(clear)
                dst.Clear();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var component = src[i];
                var source = FS.path(component.Location);
                EmitMetadump(source, dst.Path(FS.file(source.FileName.Format(), FS.Txt)));
            }
        }

        public void EmitApiMetadump(IDbArchive dst)
            => EmitMetadump(ApiMd.Parts, dst);
    }
}