//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a native executable
    /// </summary>
    public readonly struct ExeModule : IBinaryModule<ExeModule>
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public ExeModule(FilePath path)
            => Path = path;

        public FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public FileModuleKind ModuleKind
            => FileModuleKind.NativeExe;

        public FileExt DefaultExt
            => FS.Exe;

        public Assembly Load()
            => Assembly.LoadFrom(Path.Format());

        public string Format()
            => Path.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BinaryModule(ExeModule src)
            => new BinaryModule(src.Path, src.ModuleKind);
    }
}