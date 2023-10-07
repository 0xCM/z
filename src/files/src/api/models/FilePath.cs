//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    public readonly record struct FilePath : IFsEntry<FilePath>
    {
        public PathPart Name {get;}

        [MethodImpl(Inline)]
        public FilePath(PathPart name)
            => Name = PathPart.normalize(name);

        public Drive Drive
        {
            get
            {
                if(Drive.drive(Name, out var dst))
                    return dst;
                else
                    return Drive.Empty;
            }
        }

        public override int GetHashCode()
            => Hash;

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

        public bool Exists
        {
            [MethodImpl(Inline)]
            get => File.Exists(Name);
        }

        public bool Missing
        {
            [MethodImpl(Inline)]
            get => !Exists;
        }

        public FileName FileName
        {
            [MethodImpl(Inline)]
            get => new (Path.GetFileName(Name));
        }

        public FileExt Ext
        {
            [MethodImpl(Inline)]
            get => new (Path.GetExtension(Name).TrimStart('.'));
        }

        public FilePath Absolute
        {
            get => FS.absolute(this);
        }

        public FolderPath FolderPath
        {
            [MethodImpl(Inline)]
            get => new (Path.GetDirectoryName(Name));
        }

        public FolderName FolderName
        {
            [MethodImpl(Inline)]
            get => FolderPath.FolderName;
        }

        public FileInfo Info
        {
            [MethodImpl(Inline)]
            get => new FileInfo(Name);
        }

        public Timestamp Timestamp
        {
            [MethodImpl(Inline)]
            get => Info.LastWriteTime;
        }

        public string[] Components
            => FS.components(this);

        /// <summary>
        /// The size of the file in bytes
        /// </summary>
        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => FS.size(this);
        }

        public FilePath Rename(FilePath dst)
            => FS.rename(this,dst);

        public FilePath Move(FilePath dst)
            => FS.move(this,dst);

        public FilePath Copy(FilePath dst, bool overwrite = true)
            => FS.copy(this,dst, overwrite);

        public FilePath Copy(FolderPath dst, bool overwrite = true)
            => FS.copy(this,dst, overwrite);

        [MethodImpl(Inline)]
        public bool Is(FileExt ext)
            => Name.Text.EndsWith(ext.Name.Text, NoCase);

        [MethodImpl(Inline)]
        public bool Is(FileKind kind)
            => Name.Text.EndsWith(kind.Ext().Name.Text, NoCase);

        [MethodImpl(Inline)]
        public bool Is(FileExt x1, FileExt x2)
            => Is(x1 + x2);

        [MethodImpl(Inline)]
        public bool IsNot(FileExt ext)
            => !Is(ext);

        [MethodImpl(Inline)]
        public bool IsNot(FileExt x1, FileExt x2)
            => !Is(x1,x2);

        public RelativeFilePath Relative(FolderPath src)
            => FS.relative(src, this);

        public FilePath WithoutExtension
            => FolderPath + FileName.WithoutExtension;

        public FilePath ChangeExtension(FileExt ext)
            => WithoutExtension + ext;

        public FilePath ChangeExtension(FileKind kind)
            => WithoutExtension + kind.Ext();

        public string ReadText()
            => File.ReadAllText(Name);

        public string ReadUtf8()
            => File.ReadAllText(Name, Encoding.UTF8);

        public string ReadAsci()
            => File.ReadAllText(Name, Encoding.ASCII);

        public string ReadUnicode()
            => File.ReadAllText(Name, Encoding.Unicode);

        public RelativeFilePath RelativeTo(FolderPath src)
            => FS.relative(src, this);

        public FilePath Reparent(FolderPath dst)
            => FS.reparent(this, dst);

        public FilePath Replace(char src, char dst)
            => new FilePath(Name.Replace(src,dst));

        public FilePath Replace(string src, string dst)
            => new FilePath(Name.Replace(src,dst));

        /// <summary>
        /// Determines whether the filename, including the extension, ends with a specified substring
        /// </summary>
        /// <param name="substring">The substring to match</param>
        [MethodImpl(Inline)]
        public bool Contains(string substring)
            => FileName.Contains(substring);

        public bool Prefixed(FolderPath src)
            => Format().StartsWith(src.Format());
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

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(FilePath src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(FilePath src)
            => Name.Equals(src.Name);
                      
        [MethodImpl(Inline)]
        public string Format(PathSeparator sep, bool quote = false)
            => quote ? text.dquote(Name.Format(sep)) : Name.Format(sep);

        [MethodImpl(Inline)]
        public _FileUri ToUri()
            => new _FileUri(this);

        [MethodImpl(Inline)]
        public static FilePath operator +(FilePath a, FileExt b)
            => new FilePath(RP.format("{0}.{1}", a.Name, b.Name));

        public static implicit operator FileUri(FilePath src)
            => new FileUri(src.Format());

        public static implicit operator FilePath(FileUri src)
            => new FilePath(src.Format());

        public static FilePath Empty
        {
            [MethodImpl(Inline)]
            get => new FilePath(PathPart.Empty);
        }
    }
}