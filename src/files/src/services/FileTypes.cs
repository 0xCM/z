//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using Microsoft.Extensions.FileProviders;
namespace Z0
{
    public class FileKinds
    {
        public static bool @is(FilePath src, params FileKind[] kinds)
            => kinds.Where(x => src.Is(x)).Length != 0;
            
        public static FileKind kind(FilePath src)
            => kind(src.FileName);

        public static FileKind kind(FileName src)
        {
            var name = src.Format().ToLower();
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
            EnumParser<FileKind>.Service.Parse(src.Name.Format().ToLower(), out dst);
            return dst;
        }

        public static FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();

        static FileKinds()
        {
            Data = Symbols.index<FileKind>().View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        static SortedDictionary<string,FileKind> Data;
    }
}