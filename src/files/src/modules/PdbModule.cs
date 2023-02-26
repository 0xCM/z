//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly record struct PdbModule : IBinaryModule<PdbModule>
    {
        public FilePath Path {get;}
        
        [MethodImpl(Inline)]
        public PdbModule(FilePath path)
            => Path = path;

        public FileModuleKind ModuleKind
            => FileModuleKind.Unknown;

        public FileExt DefaultExt
            => FS.Pdb;

        public string Format()
            => Path.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BinaryModule(PdbModule src)
            => new BinaryModule(src.Path, src.ModuleKind);
    }
}