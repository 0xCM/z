//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ModuleArchive : IModuleArchive
    {
        public readonly FolderPath Root;

        [MethodImpl(Inline)]
        public ModuleArchive(FolderPath root)
        {
            Root = root;
        }

        FolderPath IFileArchive.Root
            => Root;


        public IEnumerable<ManagedDllFile> ManagedDll()
            => ManagedDllFiles();

        public IEnumerable<NativeDllFile> NativeDll()
            => NativeDllFiles();

        public IEnumerable<ManagedExeFile> ManagedExe()
            => ManagedExeFiles();

        public IEnumerable<NativeExeFile> NativeExe()
            => NativeExeFiles();

        public IEnumerable<NativeLibFile> Lib()
            => NativeLibFiles();

        public IEnumerable<FileModule> Members()
            => Modules();

        public IEnumerable<PdbFile> Pdb()
            => PdbFiles();

        public IEnumerable<ObjFile> Obj()
            => ObjFiles();

        public IEnumerable<DllFile> Dll()
            => DllFiles();

        public bool IsManaged(FilePath src, out AssemblyName name)
            => FS.managed(src, out name);

        IEnumerable<DllFile> DllFiles()
        {
            foreach(var path in Root.EnumerateFiles(true, FS.Dll))
                yield return new DllFile(path);
        }

        IEnumerable<PdbFile> PdbFiles()
        {
            foreach(var path in Root.EnumerateFiles(true, FS.Pdb))
                yield return new PdbFile(path);
        }

        IEnumerable<ObjFile> ObjFiles()
        {
            foreach(var path in Root.EnumerateFiles(true, FS.Obj))
                yield return new ObjFile(path);
        }

        IEnumerable<ManagedDllFile> ManagedDllFiles()
        {
            foreach(var path in Root.EnumerateFiles(true, FS.Dll, FS.ext("winmd")))
                if(IsManaged(path, out var assname))
                    yield return new ManagedDllFile(path, assname);
        }

        IEnumerable<NativeDllFile> NativeDllFiles()
        {
            foreach(var path in Root.EnumerateFiles(true,FS.Dll))
                if(FS.native(path))
                    yield return new NativeDllFile(path);
        }

        IEnumerable<ManagedExeFile> ManagedExeFiles()
        {
            foreach(var path in Root.Files(true,FS.Exe))
                if(IsManaged(path, out var assname))
                    yield return new ManagedExeFile(path, assname);
        }

        IEnumerable<NativeExeFile> NativeExeFiles()
        {
            foreach(var path in Root.Files(true,FS.Exe))
                if(FS.native(path))
                    yield return new NativeExeFile(path);
        }

        IEnumerable<NativeLibFile> NativeLibFiles()
        {
            foreach(var path in Root.Files(true,FS.Lib))
                yield return new NativeLibFile(path);
        }

        IEnumerable<FileModule> Modules()
        {
            foreach(var path in Root.EnumerateFiles(true,FS.Dll,FS.Exe,FS.Lib))
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