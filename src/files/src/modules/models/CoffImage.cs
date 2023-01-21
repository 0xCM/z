//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a managed or native image
    /// </summary>
    public readonly record struct CoffImage : IImageFile<CoffImage> 
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public CoffImage(FilePath src)
        {
            Path = src;
        }

        public FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public bool IsExe
        {
            [MethodImpl(Inline)]
            get => Path.Is(FileKind.Exe);
        }

        public bool IsDll
        {
            [MethodImpl(Inline)]
            get => Path.Is(FileKind.Dll);
        }

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(CoffImage src)
            => src.Path;
    }
}