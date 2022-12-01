//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly record struct DllFile : IFileModule<DllFile>
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public DllFile(FilePath path)
            => Path = path;

        public string Format()
            => Path.Format();

        public override string ToString()
            => Format();

        public FileModuleKind ModuleKind
            => FileModuleKind.Dll;

        public FileExt DefaultExt
            => FS.Dll;

        [MethodImpl(Inline)]
        public static implicit operator FileModule(DllFile src)
            => new FileModule(src.Path, src.ModuleKind);
    }
}