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

        INativeModule Module {get;}

        MemoryAddress Address {get;}
    }
}