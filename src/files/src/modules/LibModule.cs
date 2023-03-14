//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly struct LibModule : IBinaryModule<LibModule>
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public LibModule(FilePath path)
            => Path = path;

        public FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public FileModuleKind ModuleKind
            => FileModuleKind.NativeLib;

        public FileExt DefaultExt
            =>  FS.Lib;

        public string Format()
            => Path.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BinaryModule(LibModule src)
            => new BinaryModule(src.Path, src.ModuleKind);

    }
}