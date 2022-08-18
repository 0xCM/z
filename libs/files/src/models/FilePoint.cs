//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FilePoint
    {
        [MethodImpl(Inline), Op]
        public static FilePoint point(FS.FilePath path, LineOffset offset)
            => new FilePoint(path,offset);

        [MethodImpl(Inline), Op]
        public static FilePoint point(FS.FilePath path, LineNumber line, uint col)
            => new FilePoint(path, (line,col));

        public FS.FilePath Path {get;}

        public LineOffset Location {get;}

        [MethodImpl(Inline)]
        public FilePoint(FS.FilePath path, LineOffset loc)
        {
            Path = path;
            Location = loc;
        }

        public string Format()
            => string.Format("{0}:{1}:{2}", Path.Format(PathSeparator.BS), Location.Line, Location.Offset);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FilePoint((FS.FilePath path, LineOffset loc) src)
            => new FilePoint(src.path,src.loc);

        public static FilePoint Empty
        {
            [MethodImpl(Inline)]
            get => new FilePoint(FS.FilePath.Empty, LineOffset.Empty);
        }
    }
}