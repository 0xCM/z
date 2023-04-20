//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListedFiles : SortedSeq<ListedFile>
    {
        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.emitter();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        static void render(ListedFiles src, ITextEmitter dst)
        {
            var formatter = CsvTables.formatter<ListedFile>();
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