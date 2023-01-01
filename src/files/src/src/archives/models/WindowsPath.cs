//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct WindowsPath : IDataType<WindowsPath>
    {
        readonly FsEntry Data;

        public WindowsPath(FilePath src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public WindowsPath(FolderPath src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public string Format()
        {
            var dst = EmptyString;
            if(Data.Kind == FileObjectKind.FilePath)
                dst = ((FilePath)Data).Format(PathSeparator.BS);
            else if(Data.Kind == FileObjectKind.Directory)
                dst = ((FolderPath)Data).Format(PathSeparator.BS);
            return dst;
        }    

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        public bool Equals(WindowsPath src)
            => Data.Equals(src.Data);

        public int CompareTo(WindowsPath src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator WindowsPath(FilePath src)
            => new WindowsPath(src);

        [MethodImpl(Inline)]
        public static implicit operator WindowsPath(FolderPath src)
            => new WindowsPath(src);

        [MethodImpl(Inline)]
        public static implicit operator WindowsPath(FileUri src)
            => new WindowsPath(src);

    }
}