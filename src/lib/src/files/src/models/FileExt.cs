//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct FileExt
    {
        [MethodImpl(Inline), Op]
        public static FileExt combine(FileExt x1, FileExt x2)
            => x1 + x2;

        [MethodImpl(Inline), Op]
        public static FileExt ext(PathPart name)
            => new FileExt(name);

        [MethodImpl(Inline), Op]
        public static FileExt ext(PathPart a, PathPart b)
            => new FileExt(a,b);

        [MethodImpl(Inline), Op]
        public static FileExt ext(string a, string b)
            => new FileExt(a, b);

        [MethodImpl(Inline), Op]
        public static FileExt ext(FileExt a, FileExt b)
            => a + b;

        public PathPart Name {get;}

        public string Text
        {
            [MethodImpl(Inline)]
            get => Name.Text;
        }

        public uint PathLength
        {
            [MethodImpl(Inline)]
            get => Name.Length;
        }

        public ReadOnlySpan<char> PathData
        {
            [MethodImpl(Inline)]
            get => Name.View;
        }

        [MethodImpl(Inline)]
        public FileExt(PathPart a, PathPart b)
            : this(string.Format("{0}.{1}", a, b))
        {

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

        public string SearchPattern
        {
            [MethodImpl(Inline)]
            get => string.Format("*.{0}", Name);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(FileExt src)
            => Name.Equals(src.Name);

        public int CompareTo(FileExt src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator FileExt((FileExt a, FileExt b) src)
            => src.a + src.b;

        [MethodImpl(Inline)]
        public static FileExt operator + (FileExt a, FileExt b)
            => new(string.Format("{0}.{1}", a.Name, b.Name));

        [MethodImpl(Inline)]
        public FileExt(PathPart name)
            => Name = name;

        public static FileExt Empty
        {
            [MethodImpl(Inline)]
            get => new FileExt(PathPart.Empty);
        }
    }
}