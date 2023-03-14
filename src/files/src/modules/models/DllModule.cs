//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a native dll
    /// </summary>
    public readonly struct DllModule : IBinaryModule<DllModule>
    {
        public FilePath Path {get;}

        public FileModuleKind ModuleKind
            => FileModuleKind.NativeDll;

        [MethodImpl(Inline)]
        public DllModule(FilePath path)
            => Path = path;

        public FileName FileName
        {
            [MethodImpl(Inline)]
            get => Path.FileName;
        }

        public bool IsManaged
        {
            get => FS.managed(Path);
        }
        
        public FileExt DefaultExt
            => FS.Dll;

        public string Format()
            => Path.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BinaryModule(DllModule src)
            => new BinaryModule(src.Path, src.ModuleKind);

    }
}