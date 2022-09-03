//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CliEmitter
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
                    Cil.mdv(pe.GetMetadataReader(), target).Visualize();
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

        public void EmitMetadump(ReadOnlySpan<Assembly> src, FolderPath dst, bool clear = true)
        {
            if(clear)
                dst.Clear();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var component = skip(src,i);
                var source = FS.path(component.Location);
                var target = dst + FS.file(source.FileName.Format(), FS.Txt);
                EmitMetadump(source,target);
            }
        }

        public void EmitApiMetadump(IDbTargets dst)
            => EmitMetadump(ApiMd.Assemblies, dst.Root);
    }
}