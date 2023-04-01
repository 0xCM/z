//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IImageRef
    {
        FilePath Path {get;}

        MemoryAddress BaseAddress {get;}
    }    

    [Free]
    public interface INativeImage : IImageRef, IDisposable
    {
        ImageHandle Handle {get;}
    }
}