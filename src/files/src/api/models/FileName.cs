//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public class FileNameComparer : IComparer<FileName>, IComparer<FilePath>
    {
        public int Compare(FileName x, FileName y)
            => x.CompareTo(y);

        public int Compare(FilePath x, FilePath y)
            => Compare(x.FileName, y.FileName);
    }

    public readonly struct FileName : IFsEntry<FileName>
    {
        [Op]
        public static bool matches(FileName name, FileExt ext)
            => name.Format().EndsWith(ext.Name, NoCase);

        [MethodImpl(Inline), Op]
        public static FileName file(PathPart name, FileExt ext)
            => new FileName(name, ext);

        [Op]
        public static FileName file(PartName part, FileExt ext)
            => FS.file(part.Format(), ext);

        [Op]
        public static FileName file(PartName part, FileKind kind)
            => FS.file(part.Format(), kind.Ext());

        public static FileName file(string name, FileKind kind)
            => new FileName(name, kind.Ext());

        [Op]
        public static FileName file(PathPart name, FileExt x1, FileExt x2)
            => new FileName(name, FileExt.combine(x1,x2));

        [MethodImpl(Inline), Op]
        public static FileName file(string name)
            => new FileName(name);

        [MethodImpl(Inline), Op]
        public static FileName file(@string name, string x)
            => new FileName(name.Format(), FileExt.ext(x));

        public PathPart Name {get;}

        [MethodImpl(Inline)]
        public FileName(PathPart name)
            => Name = name;

        [MethodImpl(Inline)]
        public FileName(PathPart name, FileExt ext)
            => Name = string.Format(ExtPattern, name, ext);

        public bool HasExtension
        {
            [MethodImpl(Inline)]
            get => Path.HasExtension(Name);
        }

        public FileExt FileExt
        {
            [MethodImpl(Inline)]
            get => HasExtension ? FileExt.ext(Path.GetExtension(Name)) : FileExt.Empty;
        }

        public FileExt Ext
            => HasExtension ? new FileExt(Path.GetExtension(Name)) : FileExt.Empty;

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

        public FileName WithoutExtension
        {
            [MethodImpl(Inline)]
            get => new (Path.GetFileNameWithoutExtension(Name));
        }

        public FileName WithExtension(FileExt ext)
            => this + ext;

        public FileName ChangeExtension(FileExt ext)
            => FS.file(Path.GetFileNameWithoutExtension(Name), ext);

        public FileName ChangeExtension(FileKind kind)
            => file(Path.GetFileNameWithoutExtension(Name), kind);

        /// <summary>
        /// Determines whether the filename, begins with a specified substring
        /// </summary>
        /// <param name="substring">The substring to match</param>
        [MethodImpl(Inline)]
        public bool StartsWith(string substring)
            => Name.StartsWith(substring);

        /// <summary>
        /// Determines whether the filename, including the extension, contains a specified substring
        /// </summary>
        /// <param name="substring">The substring to match</param>
        [MethodImpl(Inline)]
        public bool Contains(string substring)
            => Name.Contains(substring);

        [MethodImpl(Inline)]
        public bool Is(FileExt ext)
            => matches(this, ext);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(FileName src)
            => Name == src.Name;

        public override bool Equals(object src)
            => src is FileName x && Equals(x);

        const string ExtPattern = "{0}.{1}";

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        public int CompareTo(FileName src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static FileName operator +(FileName a, FileExt b)
            => new FileName(string.Format("{0}.{1}", a.Name, b.Name));

        [MethodImpl(Inline)]
        public static bool operator ==(FileName a, FileName b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(FileName a, FileName b)
            => !a.Equals(b);

        public static FileName Empty
        {
            [MethodImpl(Inline)]
            get => new FileName(PathPart.Empty);
        }
    }
}