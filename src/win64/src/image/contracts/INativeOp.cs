//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeFunction
    {
        string Name {get;}

        ImageHandle Image {get;}

        MemoryAddress Address {get;}
    }

    [Free]
    public interface INativeFunction<F> : INativeFunction
    {
    }
}