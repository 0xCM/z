//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleArchive : IFileArchive
    {
        Deferred<ManagedDllFile> ManagedDll();

        Deferred<NativeDllFile> NativeDll();

        Deferred<ManagedExeFile> ManagedExe();

        Deferred<NativeExeFile> NativeExe();

        Deferred<NativeLibFile> Lib();

        Deferred<ObjFile> Obj();

        Deferred<FileModule> Members();
    }
}