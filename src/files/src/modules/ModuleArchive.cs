//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public readonly struct ModuleArchive : IModuleArchive
    {
        public readonly FolderPath Root;

        readonly bool Recurse;

        [MethodImpl(Inline)]
        public ModuleArchive(FolderPath root, bool recurse = true)
        {
            Root = root;
            Recurse = recurse;
        }

        FolderPath IRootedArchive.Root
            => Root;

        public IEnumerable<FilePath> AssemblyPaths()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Dll, FS.WinMd))
            {
                if(!path.Format().EndsWith("resources.dll"))
                {
                    if(AssemblyFile.name(path, out var name))
                        yield return path;
                }
            }

        }

        public IEnumerable<AssemblyFile> AssemblyFiles()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Dll, FS.WinMd))
            {
                if(!path.Format().EndsWith("resources.dll"))
                {
                    if(AssemblyFile.name(path, out var name))
                        yield return new AssemblyFile(path, name);
                }
            }
        }

        public IEnumerable<AssemblyFile> WinMd()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.WinMd))
                if(AssemblyFile.name(path, out var name))
                    yield return new AssemblyFile(path, name);
        }

        public IEnumerable<DllModule> NativeDll()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Dll))
                if(FS.native(path))
                    yield return new DllModule(path);
        }

        public IEnumerable<DllModule> Dll()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Dll))
                yield return new DllModule(path);            
        }

        public IEnumerable<ExeModule> Exe()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Exe))
                if(FS.native(path))
                    yield return new ExeModule(path);
        }

        public IEnumerable<LibModule> Lib()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Lib))
                yield return new LibModule(path);
        }

        public IEnumerable<BinaryModule> Members()
        {
            var managed = from module in AssemblyFiles() select generalize(module);
            var native = from module in NativeDll() select generalize(module);
            var lib = from module in Lib() select generalize(module);
            var obj = from module in Obj() select generalize(module);
            var exe = from module in Exe() select generalize(module);
            var pdb = from module in Pdb() select generalize(module);
            return managed.Union(native).Union(obj).Union(exe).Union(pdb).Union(lib);
        }
        
        public IEnumerable<PdbModule> Pdb()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Pdb))
                yield return new PdbModule(path);
        }

        public IEnumerable<ObjModule> Obj()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Obj))
                yield return new ObjModule(path);
        }

        [MethodImpl(Inline)]
        static BinaryModule generalize<T>(T src)
            where T : IBinaryModule
                => new BinaryModule(src.Path, src.ModuleKind);
    }
}