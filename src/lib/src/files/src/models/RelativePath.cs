//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;
    
    public readonly struct RelativePath :  IDataType<RelativePath>, IFsEntry<RelativePath>
    {
        public PathPart Name {get;}

        [MethodImpl(Inline)]
        public RelativePath(PathPart name)
        {
            if(name.IsNonEmpty)
            {
                ref readonly var c = ref sys.first(name.Text);
                if(c == (char)PathSeparator.BS || c == (char)PathSeparator.FS)
                    Name = text.slice(name.Text,1);
                else
                    Name = name;
            }
            else
            {
                Name = PathPart.Empty;
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(RelativePath src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public RelativePath Replace(char src, char dst)
            => new RelativePath(Name.Replace(src,dst));

        [MethodImpl(Inline)]
        public RelativePath Replace(string src, string dst)
            => new RelativePath(Name.Replace(src,dst));

        public bool Equals(RelativePath src)
            => Name == src.Name;

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public string Format(PathSeparator sep, bool quote = false)
            => quote ? text.dquote(Name.Format(sep)) : Name.Format(sep);

        [MethodImpl(Inline)]
        public static RelativePath operator +(RelativePath a, RelativePath b)
            => new (string.Format("{0}/{1}", a.Name, b.Name));

        [MethodImpl(Inline)]
        public static RelativePath operator +(RelativePath a, FolderName b)
            => new (string.Format("{0}/{1}", a.Name, b.Name));

        [MethodImpl(Inline)]
        public static RelativePath operator +(FolderName a, RelativePath b)
            => new (string.Format("{0}/{1}", a.Name, b.Name));

        [MethodImpl(Inline)]
        public static FolderPath operator +(FolderPath a, RelativePath b)
            => FS.dir(string.Format("{0}/{1}", a.Name, b.Name));

        [MethodImpl(Inline)]
        public static RelativeFilePath operator +(RelativePath a, FileName b)
            => new RelativeFilePath(relative(RP.format("{0}/{1}", a.Name, b.Name)));

        public static RelativePath Empty
        {
            [MethodImpl(Inline)]
            get => new RelativePath(PathPart.Empty);
        }
    }
    
}