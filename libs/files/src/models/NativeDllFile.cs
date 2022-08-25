//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = NativeModules;

    /// <summary>
    /// Represents a native dll
    /// </summary>
    public readonly struct NativeDllFile : IFileModule<NativeDllFile>
    {
        public FilePath Path {get;}

        public FileModuleKind ModuleKind
            => FileModuleKind.NativeDll;

        [MethodImpl(Inline)]
        public NativeDllFile(FilePath path)
            => Path = path;

        public FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public FileExt DefaultExt
            => FS.Dll;

        [MethodImpl(Inline)]
        public NativeModule Load()
            => api.load(Path);

        [MethodImpl(Inline)]
        public static implicit operator FileModule(NativeDllFile src)
            => new FileModule(src.Path, src.ModuleKind);

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(NativeDllFile src)
            => src.Path;
    }
}