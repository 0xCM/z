//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly struct ObjFile : IFileModule<ObjFile>
    {
        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public ObjFile(FilePath path)
            => Path = path;

        public FileModuleKind ModuleKind
            => FileModuleKind.Obj;

        public FileExt DefaultExt
            =>  FS.Obj;

        [MethodImpl(Inline)]
        public static implicit operator FileModule(ObjFile src)
            => new FileModule(src.Path, src.ModuleKind);
    }
}