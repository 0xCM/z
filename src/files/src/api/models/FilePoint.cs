//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct FilePoint
    {

        [Parser]
        public static bool parse(string src, out FilePoint dst)
        {
            dst = FilePoint.Empty;
            var indices = text.indices(src,Chars.Colon);
            if(indices.Length < 2)
                return false;

            var j = indices.Length -1;
            ref readonly var i0 = ref indices[j-1];
            ref readonly var i1 = ref indices[j];
            var l = text.inside(src,i0,i1);
            var c = text.right(src, i1);
            if(uint.TryParse(l, out var line) && uint.TryParse(c, out var col))
            {
                var loc = (line,col);
                var path = FS.path(text.left(src,i0));
                dst = new FilePoint(path,loc);
            }
            return true;
        }

        public FilePath Path {get;}

        public LineOffset Location {get;}

        [MethodImpl(Inline)]
        public FilePoint(FilePath path, LineOffset loc)
        {
            Path = path;
            Location = loc;
        }

        public string Format()
            => string.Format("{0}:{1}:{2}", Path.Format(PathSeparator.BS), Location.Line, Location.Offset);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FilePoint((FilePath path, LineOffset loc) src)
            => new FilePoint(src.path,src.loc);

        public static FilePoint Empty
        {
            [MethodImpl(Inline)]
            get => new FilePoint(FilePath.Empty, LineOffset.Empty);
        }
    }
}