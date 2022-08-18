//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly struct NativeLibFile : IFileModule<NativeLibFile>
    {
        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public NativeLibFile(FS.FilePath path)
            => Path = path;

        public FS.FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public FileModuleKind ModuleKind
            => FileModuleKind.NativeLib;

        public FS.FileExt DefaultExt
            =>  FS.Lib;

        [MethodImpl(Inline)]
        public static implicit operator FileModule(NativeLibFile src)
            => new FileModule(src.Path, src.ModuleKind);

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(NativeLibFile src)
            => src.Path;
    }
}