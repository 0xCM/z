//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeImage : IDisposable
    {
        MemoryAddress BaseAddress {get;}
     
        FilePath Path {get;}

        ImageHandle Handle {get;}
    }
}