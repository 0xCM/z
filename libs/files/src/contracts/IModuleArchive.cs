//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleArchive : IFileArchive
    {
        ReadOnlySeq<ManagedDllFile> ManagedDll();

        ReadOnlySeq<NativeDllFile> NativeDll();

        ReadOnlySeq<ManagedExeFile> ManagedExe();

        ReadOnlySeq<NativeExeFile> NativeExe();

        ReadOnlySeq<NativeLibFile> Lib();

        ReadOnlySeq<ObjFile> Obj();

        ReadOnlySeq<FileModule> Members();
    }
}