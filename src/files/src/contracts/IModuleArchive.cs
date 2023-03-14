//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleArchive : IRootedArchive
    {
        IEnumerable<DllModule> NativeDll();

        IEnumerable<ObjModule> Obj();

        IEnumerable<PdbModule> Pdb();

        IEnumerable<ExeModule> Exe();

        IEnumerable<FilePath> AssemblyPaths();

        IEnumerable<AssemblyFile> AssemblyFiles();

        IEnumerable<DllModule> Dll();

        IEnumerable<LibModule> Lib();

        IEnumerable<BinaryModule> Members();
    }
}