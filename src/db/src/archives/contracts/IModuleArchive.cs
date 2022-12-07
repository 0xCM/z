//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleArchive : IFileArchive
    {
        IEnumerable<DllModule> NativeDll();

        IEnumerable<ObjModule> Obj();

        IEnumerable<PdbModule> Pdb();

        IEnumerable<ExeModule> Exe();

        IEnumerable<AssemblyFile> Assemblies();

        IEnumerable<LibModule> Lib();

        IEnumerable<BinaryModule> Members();
    }
}