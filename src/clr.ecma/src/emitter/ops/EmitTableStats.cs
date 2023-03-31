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
        public void EmitTableStats(IModuleArchive src, IDbArchive dst)
        {
            var modules = src.AssemblyFiles();
            var stats = EcmaReader.stats(modules.Select(x => x.Path));
            Channel.TableEmit(stats, dst.Nested("ecma",src.Root).Table<EcmaRowStats>());
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