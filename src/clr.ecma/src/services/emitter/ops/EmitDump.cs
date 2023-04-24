//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    partial class EcmaEmitter
    {
        // public void EmitApiMetadump(IDbArchive dst)
        //     => EmitMetadump(ApiAssemblies.Components, dst.Metadata("metadump"));

        public void EmitDump(IDbArchive src, IDbArchive dst)
        {
            var index = Ecma.index(Channel, src.Root);
            iter(index.Distinct(), entry => {
                EmitDump(entry.Path, dst.Nested("ecma", dst.Root).Path(FS.file("ecma.dumps." + entry.Path.FileName.Format(), FileKind.Ecma)));
            });
        }

        public ExecToken EmitDump(FilePath src, FilePath dst)
        {
            var token = ExecToken.Empty;
            try
            {
                if(Ecma.valid(src))
                {
                    using var stream = File.OpenRead(src.Name);
                    using var pe = ImageMemory.pe(stream);
                    token = EmitDump(pe.GetMetadataReader(), dst);                    
                }
            }
            catch(BadImageFormatException bfe)
            {
                Channel.Error(bfe);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
            return token;
        }


        // public void EmitMetadumps(IWfChannel channel, IModuleArchive src, IDbArchive dst)
        // {
        //     var dlls = src.AssemblyFiles().Where(path => !path.Path.Contains(".resources.dll")).Map(x => x.Path);
        //     var exe = src.Exe().Map(x => x.Path);
        //     EmitMetadumps(channel, src.Root, dlls.Concat(exe), dst);
        // }

        // public void EmitMetadumps(IWfChannel channel, FolderPath root, IEnumerable<FilePath> src, IDbArchive dst)
        // {
        //     var index = FS.index(src);
        //     iter(index.Distinct(), entry => {
        //         var output = dst.Nested("ecma", root).Path(FS.file(entry.Path.FileName.Format(), FileKind.Ecma));
        //         EmitMetadump(entry.Path, output);
        //     },PllExec);
        // }


        public void EmitDump(IWfChannel channel, IEnumerable<Assembly> src, IDbArchive dst)
            => iter(src, x => EmitDump(Channel, x, dst.Path(x.GetSimpleName(), FileKind.Txt)), PllExec);

        public ExecToken EmitDump(MetadataReader reader, FilePath dst)
        {            
            var token = ExecToken.Empty;
            try
            {
                var flow = Channel.EmittingFile(dst);
                using var target = dst.Writer();
                MsilCodeModels.mdv(reader, target).Visualize();
                token = Emitter.EmittedFile(flow);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
            return token;            
        }

        // public void EmitMetadump(ReadOnlySeq<Assembly> src, IDbArchive dst, bool clear = true)
        // {
        //     if(clear)
        //         dst.Clear();
        //     var count = src.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         var component = src[i];
        //         var source = FS.path(component.Location);
        //         EmitMetadump(source, dst.Path(FS.file(source.FileName.Format(), FS.Txt)));
        //     }
        // }

        public ExecToken EmitDump(IWfChannel channel, Assembly src, FilePath dst)
        {
            var token = ExecToken.Empty;
            try
            {
                var flow = channel.EmittingFile(dst);
                using var target = dst.Writer();
                var reader = EcmaReader.create(src);
                MsilCodeModels.mdv(reader.MetadataReader, target).Visualize();
                token = channel.EmittedFile(flow);
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
            return token;
        }
    }
}