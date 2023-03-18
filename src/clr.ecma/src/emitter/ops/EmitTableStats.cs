//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;
    using static EcmaTables;

    partial class EcmaEmitter
    {        
        static FolderPath nested(FolderPath root, FilePath src)
            => root + FS.folder(FS.components(src.FolderPath).Join('/'));

        static FolderPath nested(FolderPath root, FolderPath src)
            => root + FS.folder(FS.components(src).Join('/'));

        public void EmitTableStats(IModuleArchive src, IDbArchive dst)
        {
            var modules = src.AssemblyFiles();
            var stats = EcmaReader.stats(modules.Select(x => x.Path));
            var folder = Archives.nested(dst.Root, src.Root);
            var path = folder.DbArchive().Table<EcmaRowStats>();
            Channel.TableEmit(stats,path);

        }
        public void EmitTableStats(ReadOnlySpan<Assembly> src, IDbArchive dst)
        {
            var buffer = bag<EcmaRowStats>();
            EcmaReader.stats(src,buffer);
            var rows = buffer.ToSeq().Sort();
            Channel.TableEmit(rows, dst.Metadata().Table<EcmaRowStats>());
        }

        public void EmitTableStats(ReadOnlySpan<Assembly> src, FilePath dst)
        {
            var buffer = bag<EcmaRowStats>();
            EcmaReader.stats(src,buffer);
            var rows = buffer.ToSeq().Sort();
            Channel.TableEmit(rows, dst);
        }
    }
}