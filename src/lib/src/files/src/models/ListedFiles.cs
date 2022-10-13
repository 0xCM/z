//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListedFiles : SortedSeq<ListedFile>
    {
        public static ListedFiles listing(FolderPath src, bool recurse)
            => src.Files(recurse).Map(listing).Array();

        public static ListedFiles listing(FolderPath src, bool recurse, params FileKind[] kinds)
            => src.Files(recurse,kinds).Map(listing).Array();

        public static ListedFiles listing(ReadOnlySpan<FilePath> src)
            => src.Select(listing);

        public static ListedFile listing(FilePath src)
        {
            var dst = new ListedFile();
            var info = new FileInfo(src.Name);
            dst.Size = ((ByteSize)info.Length).Kb;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Path = src;
            dst.Attributes = info.Attributes;
            return dst;
        }

        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.emitter();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void render(ListedFiles src, ITextEmitter dst)
        {
            var formatter = Tables.formatter<ListedFile>();
            dst.AppendLine(formatter.FormatHeader());
            for(var i=0u; i<src.Count; i++)
                dst.AppendLine(formatter.Format(src[i]));
        }

        public ListedFiles()
        {

        }

        [MethodImpl(Inline)]
        public ListedFiles(ListedFile[] src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public ListedFiles(ReadOnlySeq<ListedFile> src)
            : base(src.Unwrap())
        {

        }

        public override string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ListedFiles(ListedFile[] src)
            => new ListedFiles(src);
    }
}