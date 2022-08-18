//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents and managaged module that lacks an entry point
    /// </summary>
    public readonly struct ManagedDllFile : IFileModule<ManagedDllFile>
    {
        /// <summary>
        /// The file's path
        /// </summary>
        public FS.FilePath Path {get;}

        /// <summary>
        /// The assembly name
        /// </summary>
        public AssemblyName Name {get;}

        [MethodImpl(Inline)]
        public ManagedDllFile(FS.FilePath path, AssemblyName name)
        {
            Path = path;
            Name = name;
        }

        public FS.FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public FS.FileExt DefaultExt
            => FS.Dll;

        public FileModuleKind ModuleKind
            => FileModuleKind.ManagedDll;

        public Assembly Load()
            => Assembly.LoadFrom(Path.Name);

        public string Format()
            => Path.ToUri().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FileModule(ManagedDllFile src)
            => new FileModule(src.Path, src.ModuleKind);

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(ManagedDllFile src)
            => src.Path;

    }
}