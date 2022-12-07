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

        FolderPath IFileArchive.Root
            => Root;

        public IEnumerable<AssemblyFile> Assemblies()
        {
            foreach(var path in Root.EnumerateFiles(Recurse, FS.Dll, FS.ext("winmd")))
                if(FS.managed(path, out var assname))
                    yield return new AssemblyFile(new FileUri(path.ToUri().Format()), assname);
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
            foreach(var path in Root.Files(Recurse, FS.Exe))
                if(FS.native(path))
                    yield return new ExeModule(path);
        }

        public IEnumerable<LibModule> Lib()
        {
            foreach(var path in Root.Files(Recurse, FS.Lib))
                yield return new LibModule(path);
        }

        public IEnumerable<BinaryModule> Members()
        {
            var managed = from module in Assemblies() select generalize(module);
            var native = from module in NativeDll() select generalize(module);
            var obj = from module in Obj() select generalize(module);
            var exe = from module in Exe() select generalize(module);
            var pdb = from module in Pdb() select generalize(module);
            return managed.Union(native).Union(obj).Union(exe).Union(pdb);
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
                => new BinaryModule(src.Location, src.ModuleKind);
    }
}