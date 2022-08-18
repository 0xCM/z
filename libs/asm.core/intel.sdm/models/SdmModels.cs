//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public readonly partial struct SdmModels
    {
        [MethodImpl(Inline), Op]
        public static ChapterNumber chapter(byte number)
            => new ChapterNumber(number);

        [MethodImpl(Inline), Op]
        public static TocEntry toc(VolNumber vol, in SectionNumber sn, in TocTitle title)
            => new TocEntry(vol, sn, title);

        [MethodImpl(Inline), Op]
        public static TableNumber tablenumber(ReadOnlySpan<char> src)
            => new TableNumber(src);

        [MethodImpl(Inline), Op]
        public static TableTitle title(in TableNumber table, ReadOnlySpan<char> label)
            => new TableTitle(table, label);

        [MethodImpl(Inline), Op]
        public static TocTitle title(in CharBlock128 title, in ChapterPage page)
            => new TocTitle(title, page);

        [MethodImpl(Inline), Op]
        public static DocLocation location(in VolPart v, in ChapterNumber c, in Page p)
            => new DocLocation(v, c, p);

        [MethodImpl(Inline), Op]
        public static ChapterPage page(in ChapterNumber chapter, in Page page)
            => new ChapterPage(chapter, page);

        [MethodImpl(Inline), Op]
        public static ChapterPage page(in ChapterNumber chapter, ushort page)
            => new ChapterPage(chapter, page);

        [MethodImpl(Inline), Op]
        public static SectionPage page(in SectionNumber section, in ChapterPage page)
            => new SectionPage(section, page);

        [MethodImpl(Inline), Op]
        public static PageFooter footer(in CharBlock16 l0, in CharBlock16 l1, in CharBlock16 r0, in CharBlock16 r1)
            => new PageFooter(l0, l1, r0, r1);

        [MethodImpl(Inline), Op]
        public static VolPartNumber volpart(byte major, char minor)
            => new VolPartNumber(major, (AsciCode)minor);

        [Op]
        static void render(in LineNumber line, ITextBuffer dst)
        {
            dst.AppendFormat(string.Format("{0}:", line));
        }

        [Op]
        public static void render(in SectionNumber sn, in ChapterPage cp, ITextBuffer dst)
        {
            dst.Append("Section ");
            render(sn, dst);
            dst.Append(" Page ");
            render(cp, dst);
        }

        [Op]
        public static void render(in LineNumber line, in TocEntry src, ITextBuffer dst)
        {
            render(line, dst);
            render(src, dst);
        }

        [Op]
        public static void render(in TocEntry src, ITextBuffer dst)
        {
            dst.Append(src.Title.String);
            dst.Append(" -> ");
            render(src.Section, src.Page, dst);
        }

        [Op]
        public static void render(in TocTitle src, ITextBuffer dst)
        {
            dst.Append(src.Content.String);
            dst.Append(Chars.Space);
            dst.Append("Page(");
            render(src.Page, dst);
            dst.Append(")");
        }

        [Op]
        public static void render(in SectionPage src, ITextBuffer dst)
        {
            dst.Append(Chars.LBracket);
            render(src.Section, dst);
            dst.Append(Chars.Space);
            render(src.Page, dst);
            dst.Append(Chars.RBracket);
        }

        [Op]
        public static string format(in SectionPage src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void render(in ChapterPage cp, ITextBuffer dst)
        {
            dst.AppendFormat(ContentPatterns.ChapterPage, cp.Chapter, cp.Page);
        }

        [Op]
        public static void render(in LineNumber line, in ChapterNumber cn, ITextBuffer dst)
        {
            render(line, dst);
            dst.AppendFormat(ContentPatterns.ChapterNumber, cn.Value);
        }

        [Op]
        public static void render(in LineNumber line, in SectionNumber sn, ITextBuffer dst)
        {
            render(line, dst);
            render(sn, dst);
        }

        [Op]
        public static string format(in TableNumber src)
            => text.format(src.String);

        [Op]
        public static void render(in LineNumber line, in TableNumber table, ITextBuffer dst)
        {
            render(line, dst);
            dst.AppendFormat("Table {0}", format(table));
        }

        [Op]
        public static void render(in TableTitle src, ITextBuffer dst)
        {
            dst.AppendFormat("{0}. {1}", format(src.Table), text.format(src.Label.String));
        }

        [Op]
        public static string format(in TableTitle src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void render(in SectionNumber src, ITextBuffer dst)
        {
            const string EmptyMarker = "<empty>";
            const string N1Pattern = "{0}";
            const string N2Pattern = "{0}.{1}";
            const string N3Pattern = "{0}.{1}.{2}";
            const string N4Pattern = "{0}.{1}.{2}.{3}";
            const string OverflowMarker = "<overflow>";

            switch(src.Count)
            {
                case 0:
                    dst.Append(EmptyMarker);
                break;
                case 1:
                    dst.AppendFormat(N1Pattern, src.A);
                break;
                case 2:
                    dst.AppendFormat(N2Pattern, src.A, src.B);
                break;
                case 3:
                    dst.AppendFormat(N3Pattern, src.A, src.B, src.C);
                break;
                case 4:
                    dst.AppendFormat(N4Pattern, src.A, src.B, src.C, src.D);
                break;
                default:
                    dst.Append(OverflowMarker);
                break;
            }
        }

        [Op]
        public static string format(in SectionNumber src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        public static string format(in TocEntry src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }

        [Op]
        public static string format(in TocTitle src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }
    }
}