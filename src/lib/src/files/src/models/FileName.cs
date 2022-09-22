//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public readonly struct FileName : IFsEntry<FileName>
    {
        [Op]
        public static bool matches(FileName name, FileExt ext)
            => name.Format().EndsWith(ext.Name, NoCase);

        [MethodImpl(Inline), Op]
        public static FileName file(PathPart name, FileExt ext)
            => new FileName(name, ext);

        [Op]
        public static FileName file(PartId part, FileExt ext)
            => file(part.Format(), ext);

        [Op]
        public static FileName file(PartId part, FileKind kind)
            => file(part.Format(), kind.Ext());

        [MethodImpl(Inline), Op]
        public static FileName file(Identifier name, string type)
            => new FileName(name.Content, FileExt.ext(type));

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

        // public PartId Owner
        //     => FS.part(this);

        // [MethodImpl(Inline)]
        // public bool IsOwner(PartId id)
        //     => id == Owner;

        public FileName ChangeExtension(FileExt ext)
            => file(Path.GetFileNameWithoutExtension(Name), ext);

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

        // /// <summary>
        // /// Converts this filename to a <see cref='FilePath'/>
        // /// </summary>
        // [MethodImpl(Inline)]
        // public FilePath ToPath()
        //     => new FilePath(Name);

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