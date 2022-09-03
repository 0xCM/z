//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct Markdown
    {
        [MethodImpl(Inline), Op]
        public static Doc doc(ISection[] src)
            => new Doc(src);

        public static Doc doc(uint sections)
            => new Doc(alloc<ISection>(sections));

        [MethodImpl(Inline), Op]
        public static Section section(uint index, SectionHeader header, string content)
            => new Section(index, header,content);

        [MethodImpl(Inline), Op]
        public static ListItem item<T>(Level level, T content)
            => new ListItem(level, content.ToString());

        public List list(ReadOnlySpan<string> src, DepthIndicator style)
        {
            var count = src.Length;
            var dst = new ListItem[count];
            for(var i=0; i<count; i++)
                seek(dst,i) = item(level(1, style), skip(src,i));
            return new List(dst,style);
        }

        [MethodImpl(Inline), Op]
        public static Level level(byte depth, DepthIndicator indicator)
            => new Level(depth, indicator);

        [MethodImpl(Inline), Op]
        public static LinkTarget<T> target<T>(T dst)
            => dst;

        [MethodImpl(Inline), Op]
        public static PageTitle title(Name name, string content)
            => new PageTitle(name,content);

        [MethodImpl(Inline), Op]
        public static Label label(string content)
            => content;

        [MethodImpl(Inline), Op]
        public static Name name(string content)
            => content;

        [MethodImpl(Inline), Op]
        public static SectionHeader header(byte depth, Name name)
            => new (depth,name);

        [MethodImpl(Inline), Op]
        public static SectionLink link(Label label, Name dst)
            => new SectionLink(label, dst);

        [MethodImpl(Inline), Op]
        public static SectionLink link(Name dst)
            => new SectionLink(label(dst.Content), dst);

        public static Index<RelativeLink> links(FolderPath @base, Files files)
        {
            var relative = files.Map(f => f.Relative(@base));
            var count = relative.Length;
            var dst = alloc<RelativeLink>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = Markdown.link(skip(relative,i));
            return dst;
        }

        public static Index<AbsoluteLink> links(Files files)
            => files.Map(f => link(f.FileName.WithoutExtension.Format(),f));

        [MethodImpl(Inline), Op]
        public static RelativeLink link(Label label, RelativeFilePath src)
            => new RelativeLink(label, src);

        [MethodImpl(Inline), Op]
        public static RelativeLink link(RelativeFilePath src)
            => new RelativeLink(src.File.Format(), src);

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(Label label, FilePath dst)
            => new AbsoluteLink(label, dst.ToUri(), false);

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(Label label, FileUri dst)
            => new AbsoluteLink(label, dst, false);

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(FilePath dst, bool bare = true)
            => new AbsoluteLink(dst.FileName.WithoutExtension.Format(), dst.ToUri(), bare);
    }
}