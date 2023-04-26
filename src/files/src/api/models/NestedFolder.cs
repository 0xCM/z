//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct NestedFolder
    {
        public readonly FolderPath Root;

        public readonly ReadOnlySeq<string> Components;

        public NestedFolder(FolderPath root, ReadOnlySeq<string> components)
        {
            Root = root;
            Components = components;
        }

        public FolderPath Path
            => Root + FS.folder(text.join(Chars.FSlash, Components));

        public string Format(PathSeparator sep, bool quote = false)
            => Path.Format(sep, quote);
        
        public string Format()
            => Path.Format();
        
        public int CompareTo(NestedFolder src)
            => Path.CompareTo(src.Path);

        public IDbArchive DbArchive()
            => Path.DbArchive();
    }
}
