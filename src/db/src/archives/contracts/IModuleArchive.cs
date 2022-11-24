//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleArchive : IFileArchive
    {
        IEnumerable<DllFile> Dll();

        IEnumerable<ObjFile> Obj();

        IEnumerable<PdbFile> Pdb();

        IEnumerable<ManagedDllFile> ManagedDll();

        IEnumerable<NativeDllFile> NativeDll();

        IEnumerable<ManagedExeFile> ManagedExe();

        IEnumerable<NativeExeFile> NativeExe();

        IEnumerable<NativeLibFile> Lib();

        IEnumerable<FileModule> Members();
    }
}