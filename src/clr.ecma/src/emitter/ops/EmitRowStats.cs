//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitRowStats(IApiPack dst)
        {
            var src = ApiMd.Parts;
            var buffer = bag<EcmaRowStats>();
            stats(src,buffer);
            EmitRowStats(ApiMd.Parts, dst.Metadata().Table<EcmaRowStats>());
        }

        public void EmitRowStats(ReadOnlySpan<Assembly> src, FilePath dst)
        {
            var buffer = bag<EcmaRowStats>();
            stats(src,buffer);
            var rows = buffer.ToSeq().Sort();
            TableEmit(rows, dst);
        }

        public static void stats(ReadOnlySpan<Assembly> src, ConcurrentBag<EcmaRowStats> dst)
            => iter(src, a => stats(a,dst), PllExec);

        public static void stats(Assembly src, ConcurrentBag<EcmaRowStats> dst)
            => EcmaReader.stats(EcmaReader.create(src), dst);

    }
}