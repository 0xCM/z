//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;

    public class FileTypes
    {
        public static bool @is(FilePath src, params FileKind[] kinds)
            => kinds.Where(x => src.Is(x)).Length != 0;
            
        public static FileKind kind(FilePath src)
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

        public static bool parse(string src, out FileKind dst)
        {
            var symbols = Symbols.index<FileKind>();
            return symbols.ExprKind(src.ToLower(), out dst);
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

        public static FileKind FileKind(this FileName src)
            => FileTypes.kind(src.Ext);

        public static FileKind FileKind(this FilePath src)
            => FileTypes.kind(src. FileName.Ext);

        public static string SrcId(this FilePath src, params FileKind[] kinds)
            => src.FileName.SrcId(kinds);

        public static string SrcId(this FileName src, params FileKind[] kinds)
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