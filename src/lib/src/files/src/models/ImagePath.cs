//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ImagePath : IFile<FilePath>
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public ImagePath(FilePath src)
        {
            Path = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Path.Hash;
        }

        public FilePath Location
        {
            [MethodImpl(Inline)]
            get => Path;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(ImagePath src)
            => Path.Equals(src.Path);

        public string Format()
            => Path.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(FilePath src)
            => new ImagePath(src);

        [MethodImpl(Inline)]
        public static implicit operator FilePath(ImagePath src)
            => src.Path;
    }
}