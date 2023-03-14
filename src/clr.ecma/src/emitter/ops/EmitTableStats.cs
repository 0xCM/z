//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaEmitter
    {        
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