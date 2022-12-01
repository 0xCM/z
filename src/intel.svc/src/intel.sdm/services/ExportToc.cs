//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
    using static SdmModels;

    partial class IntelSdm
    {
        public void ExportToc()
        {
            EmitCombinedToc();
            EmitTocRecords();
        }

        void EmitCombinedToc()
        {
            var result = Outcome.Success;
            var src = SdmPaths.TocPaths();

            if(src.IsEmpty)
                return;
            var encoding = Tuples.pair(TextEncodingKind.Unicode, TextEncodingKind.Unicode);
            var dst = SdmPaths.TocImportDoc();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                var name = path.FileName.WithoutExtension.Format();
                var last = name.Length - 1;
                if(last > 0)
                {
                    var vol = (byte)Digital.digit(name[last]);

                }
            }

            CombineDocs(src, dst, encoding);            
        }


        public Outcome EmitTocRecords()
        {
            var result = Outcome.Success;
            var src = SdmPaths.TocImportDoc();
            if(!src.Exists)
            {
                result = (false,FS.missing(src));
                Error(result.Message);
                return result;
            }

            var encoding = TextEncodingKind.Unicode;
            using var reader = src.LineReader(encoding);
            var buffer = text.buffer();
            var dst = SdmPaths.ProcessLog("toc.combined");
            using var writer = dst.Writer(encoding);
            var cn = ChapterNumber.Empty;
            var tn = TableNumber.Empty;
            var title = TocTitle.Empty;
            var entry = TocEntry.Empty;
            var vn = VolNumber.Empty;
            var entries = list<TocEntry>();
            var _snbuffer = span<SectionNumber>(1);
            ref var _sn = ref first(_snbuffer);
            _sn = SectionNumber.Empty;
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var number = line.LineNumber;
                if(content.Contains(ContentMarkers.VolNumber))
                {
                    result = SdmOps.parse(content, out vn);
                    if(result.Fail)
                        break;

                    writer.WriteLine(string.Format("{0}:{1}", number, content));
                }

                if(SdmOps.parse(content, out cn))
                {
                    render(number, cn, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }

                if(SdmOps.parse(content, out SectionNumber sn))
                {
                    _sn = sn;
                    render(number, _sn, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }

                if(SdmOps.parse(content, out title))
                {
                    entry = toc(vn, _sn, title);
                    entries.Add(entry);
                    render(number, entry, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }

                if(SdmOps.parse(content, out tn))
                {
                    render(number, tn, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }
            }

            if(result.Ok)
                TableEmit(entries.ViewDeposited(), SdmPaths.TocDst(), encoding);
            return result;
        }

    }
}