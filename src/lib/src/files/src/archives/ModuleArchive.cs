//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;
    
    public readonly struct ModuleArchive : IModuleArchive
    {
        [Op]
        public static Files managed(FolderPath src, bool recurse = false, bool dll = true, bool exe = true)
        {
            var dst = Files.Empty;
            if(dll && exe)
                dst = FS.files(src, recurse, Dll, Exe).Array().Where(FS.managed);
            else if(!exe && dll)
                dst = FS.files(src, recurse, Dll).Array().Where(FS.managed);
            else if(exe && !dll)
                dst = FS.files(src, recurse, Exe).Array().Where(FS.managed);
            return dst;
        }

        public readonly FolderPath Root;

        [MethodImpl(Inline)]
        public ModuleArchive(FolderPath root)
        {
            Root = root;
        }

        FolderPath IFileArchive.Root
            => Root;

        public Deferred<ManagedDllFile> ManagedDll()
            => ManagedDllFiles().Defer();

        public Deferred<NativeDllFile> NativeDll()
            => NativeDllFiles().Defer();

        public Deferred<ManagedExeFile> ManagedExe()
            => ManagedExeFiles().Defer();

        public Deferred<NativeExeFile> NativeExe()
            => NativeExeFiles().Defer();

        public Deferred<NativeLibFile> Lib()
            => NativeLibFiles().Defer();

        public Deferred<FileModule> Members()
            => Modules().Defer();

        public Deferred<ObjFile> Obj()
            => ObjFiles().Defer();

        public bool IsManaged(FilePath src, out AssemblyName name)
            => FS.managed(src, out name);

        IEnumerable<ObjFile> ObjFiles()
        {
            foreach(var path in Root.Files(true))
                if(path.Is(FS.Obj))
                    yield return new ObjFile(path);
        }

        IEnumerable<ManagedDllFile> ManagedDllFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Dll) || f.Is(FileKind.WinMd.Ext())))
                if(IsManaged(path, out var assname))
                    yield return new ManagedDllFile(path, assname);
        }

        IEnumerable<NativeDllFile> NativeDllFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Dll)))
                if(FS.native(path))
                    yield return new NativeDllFile(path);
        }

        IEnumerable<ManagedExeFile> ManagedExeFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Exe)))
                if(IsManaged(path, out var assname))
                    yield return new ManagedExeFile(path, assname);
        }

        IEnumerable<NativeExeFile> NativeExeFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Exe)))
                if(FS.native(path))
                    yield return new NativeExeFile(path);
        }

        IEnumerable<NativeLibFile> NativeLibFiles()
        {
            foreach(var path in Root.Files(true))
                if(path.Is(FS.Lib))
                    yield return new NativeLibFile(path);
        }

        IEnumerable<FileModule> Modules()
        {
            foreach(var path in Root.Files(true))
            {
                if(path.Is(FS.Dll))
                {
                    if(IsManaged(path, out var assname))
                        yield return new ManagedDllFile(path, assname);
                    else
                        yield return new NativeDllFile(path);
                }
                else if(path.Is(FS.Exe))
                {
                    if(IsManaged(path, out var assname))
                        yield return new ManagedExeFile(path, assname);
                    else
                        yield return new NativeExeFile(path);
                }
                else if(path.Is(FS.Lib))
                    yield return new NativeLibFile(path);
            }
        }
    }
}