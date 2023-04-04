//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeImage : IDisposable
    {
        FilePath Path {get;}

        MemoryAddress BaseAddress {get;}

        ImageHandle Handle {get;}

        MemoryAddress GetProcAddress(string name);

        NativeExport GetExport(Label name);
    }
}