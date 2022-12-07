//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies and represents a native static library
    /// </summary>
    public readonly record struct ObjModule : IBinaryModule<ObjModule>
    {
        public FileUri Path {get;}

        [MethodImpl(Inline)]
        public ObjModule(FilePath path)
            => Path = path;

        public FileModuleKind ModuleKind
            => FileModuleKind.Obj;

        public FileExt DefaultExt
            => FS.Obj;

        [MethodImpl(Inline)]
        public static implicit operator BinaryModule(ObjModule src)
            => new BinaryModule(src.Path, src.ModuleKind);
    }
}