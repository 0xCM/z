//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IImageRef
{
    string ImageName {get;}

    FilePath ResolvedPath {get;}

    MemoryAddress BaseAddress {get;}

    ImageHandle Handle {get;}

    MemoryAddress GetProcAddress(string name);

    NativeExport GetExport(Label name);
}
