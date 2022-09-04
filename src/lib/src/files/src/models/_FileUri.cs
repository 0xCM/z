//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public readonly record struct _FileUri : IFsEntry<_FileUri>
    {
        readonly FilePath Source;

        public PathPart Name
            => Format();

        [MethodImpl(Inline)]
        public _FileUri(FilePath src)
            => Source = src.Replace("file:///", EmptyString);

        [MethodImpl(Inline)]
        public _FileUri(FolderPath src)
            => Source = FS.path(src.Replace("file:///", EmptyString).Name);

        public _FileUri LineRef(uint line)
            => new _FileUri(path(string.Format("{0}#{1}", this,line)));
        public string Format()
            => string.Format("file:///{0}", Source.Format());

        public string FormatMarkdown(string label = null)
            => string.Format("[{0}]({1})", label ?? Source.FileName.Format(), Format());

        public string MarkdownBullet(string label = null)
            => string.Format("* {0}", Source.ToUri().FormatMarkdown(label));

        public bool Equals(_FileUri src)
            => Source.Equals(src.Source);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Source.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public _FileUri WithoutLine
        {
            get
            {
                var src = Source.Format();
                var i = text.index(src,Chars.Hash);
                if(i > 0)
                {
                    return FS.path(text.left(src,i));
                }
                else
                    return this;
            }
        }

        public FilePath Path
            => WithoutLine.Source;

        public override string ToString()
            => Format();

        public int CompareTo(_FileUri src)
            => Source.CompareTo(src.Source);

        [MethodImpl(Inline)]
        public static implicit operator _FileUri(FilePath src)
            => new _FileUri(src);

        [MethodImpl(Inline)]
        public static explicit operator FilePath(_FileUri src)
            => src.Path;

        [MethodImpl(Inline)]
        public static implicit operator FileUri(_FileUri src)
            => new FileUri(src.Format());

        public static _FileUri Empty => new _FileUri(FilePath.Empty);
    }
}