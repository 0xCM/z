//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitMetadumps(IWfChannel channel, FolderPath root, Deferred<FilePath> src, IDbArchive dst)
        {
            var @base = Archives.identifier(root);
            iter(src, input => {
                var output = dst.Scoped(@base).Path(FS.file(input.FileName.Format(), FileKind.Ecma));
                EmitMetadump(input, output);
            },PllExec);
        }

        public void EmitMetadumps(IWfChannel channel, IModuleArchive src, IDbArchive dst)
        {
            var dlls = src.ManagedDll().Where(path => !path.Path.Contains(".resources.dll")).Select(x => x.Path);
            var exe = src.ManagedExe().Select(x => x.Path);
            EmitMetadumps(channel, src.Root, dlls.Concat(exe), dst);
        }

        public void EmitMetadumps(IWfChannel channel, IEnumerable<Assembly> src, IDbArchive dst)
            => iter(src, x => EmitMetadump(channel, x, dst.Path(x.GetSimpleName(), FileKind.Txt)), PllExec);

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

        public Task<ExecToken> EmitMetadump(IWfChannel channel, Assembly src, FilePath dst)
        {
            ExecToken Exec()
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
            return sys.start(Exec);
        }
    }
}