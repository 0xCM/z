//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [SymSource(nameof(llvm))]
    public enum LlvmConfigKind : byte
    {
        [Symbol("version", "LLVM version")]
        Version,

        [Symbol("libs", "Libraries needed to link against LLVM components")]
        Libs,

        [Symbol("includedir", "Directory containing LLVM headers")]
        IncludeDir,

        [Symbol("libdir", "Directory containing LLVM libraries")]
        LibDir,

        [Symbol("libnames", "Bare library names for in-tree builds")]
        LibNames,

        [Symbol("libfiles", "Fully qualified library filenames for makefile depends")]
        LibFiles,

        [Symbol("ldflags", "Linker flags")]
        LinkerFlags,

        [Symbol("targets-built", "List of all targets currently built")]
        TargetsBuilt,

        [Symbol("src-root", "The source root LLVM was built from")]
        SrcRoot,

        [Symbol("obj-root", "The object root used to build LLVM")]
        ObjRoot,

        [Symbol("components", "Available components")]
        Components,

        [Symbol("cppflags", "C preprocessor flags for files that include LLVM headers")]
        CppFlags,

        [Symbol("cflags", "C compiler flags for files that include LLVM headers")]
        CFlags,

        [Symbol("cflags", "C++ compiler flags for files that include LLVM headers")]
        CxxFlags,

        [Symbol("system-libs", "System Libraries needed to link against LLVM components")]
        SystemLibs,

        [Symbol("host-target", "Target triple used to configure LLVM")]
        HostTarget,

        [Symbol("bindir", "Directory containing LLVM executables")]
        BinDir,

        [Symbol("link-static", "Component static link")]
        LinkStatic,
    }
}