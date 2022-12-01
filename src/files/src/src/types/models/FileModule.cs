//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a managed or native image
    /// </summary>
    public readonly record struct FileModule : IFileModule<FileModule>
    {
        public FilePath Path {get;}

        public FileModuleKind ModuleKind {get;}

        [MethodImpl(Inline)]
        public FileModule(FilePath src, FileModuleKind kind)
        {
            Path = src;
            ModuleKind = kind;
        }

        public bool IsManaged
        {
            [MethodImpl(Inline)]
            get => (ModuleKind & FileModuleKind.Managed) != 0;
        }

        public bool IsExe
        {
            [MethodImpl(Inline)]
            get => (ModuleKind & FileModuleKind.Exe) != 0;
        }

        public bool IsDll
        {
            [MethodImpl(Inline)]
            get => (ModuleKind & FileModuleKind.Dll) != 0;
        }

        public bool IsStaticLib
        {
            [MethodImpl(Inline)]
            get => (ModuleKind & FileModuleKind.Lib) != 0;
        }

        public bool IsNative
        {
            [MethodImpl(Inline)]
            get => (ModuleKind & FileModuleKind.Native) != 0;
        }

        public bool IsObj
        {
            [MethodImpl(Inline)]
            get => (ModuleKind & FileModuleKind.Obj) != 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator ImagePath(FileModule src)
            => src.Path;
    }
}