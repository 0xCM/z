//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public class AsmEtl : AppService<AsmEtl>
    {
        public static ReadOnlySpan<TextLine> emit(SortedSpan<AsmThumbprint> src, FS.FilePath dst)
        {
            var count = src.Length;
            var lines = span<TextLine>(count);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                var content = AsmThumbprint.bitstring(src[i]);
                writer.WriteLine(content);
                seek(lines,i) = (i,content);
            }
            return lines;
        }

        public SortedSpan<AsmThumbprint> EmitThumbprints(ReadOnlySpan<HostAsmRecord> src, FS.FilePath dst)
        {
            var distinct = AsmThumbprint.distinct(src);
            emit(distinct, dst);
            return distinct;
        }

        [Op]
        public Outcome EmitThumbprints(Index<AsmThumbprint> src, FS.FilePath dst)
        {
            var count = src.Length;
            src.Sort();
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(src[i].Format());
            return true;
        }
    }
}