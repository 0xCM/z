//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;

    public class FileTypes
    {
        public static FileKind kind(FS.FilePath src)
        {
            var name = src.FileName.Format().ToLower();
            var kind = FileKind.None;
            foreach(var expr in Data)
            {
                if(name.EndsWith(expr.Key))
                {
                    kind = expr.Value;
                    break;
                }
            }
            return kind;
        }

        public static FileKind kind(FileExt src)
        {
            var dst = FileKind.None;
            var symbols = Symbols.index<FileKind>();
            symbols.ExprKind(src.Format(), out dst);
            return dst;
        }

        public static FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();

        static FileTypes()
        {
            Data = Symbols.index<FileKind>().View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        static SortedDictionary<string,FileKind> Data;
    }

    public static class XFiles
    {
        public static FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static string Format(this FileKind src)
            => FileTypes.format(src);

        public static FileKind FileKind(this FileExt src)
            => FileTypes.kind(src);

        public static FileKind FileKind(this FS.FileName src)
            => FileTypes.kind(src.Ext);

        public static FileKind FileKind(this FS.FilePath src)
            => FileTypes.kind(src. FileName.Ext);

        public static string SrcId(this FS.FilePath src, params FileKind[] kinds)
            => src.FileName.SrcId(kinds);

        public static string SrcId(this FS.FileName src, params FileKind[] kinds)
        {
            var file = src.Format();
            var count = kinds.Length;
            var id = EmptyString;
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                var ext = kind.Ext();
                var j = text.index(file, "." + ext);
                if(j >0)
                {
                    id = text.left(file,j);
                    break;
                }
            }
            return id;
        }
    }
}