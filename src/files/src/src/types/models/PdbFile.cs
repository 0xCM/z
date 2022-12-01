//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly record struct PdbFile : IFileModule<PdbFile>
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public PdbFile(FilePath path)
            => Path = path;

        public FileModuleKind ModuleKind
            => FileModuleKind.Unknown;

        public FileExt DefaultExt
            => FS.Pdb;

        [MethodImpl(Inline)]
        public static implicit operator FileModule(PdbFile src)
            => new FileModule(src.Path, src.ModuleKind);
    }
}