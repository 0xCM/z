//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeOp
    {
        string Name {get;}

        ImageHandle Image {get;}

        MemoryAddress Address {get;}
    }

    [Free]
    public interface INativeOp<F> : INativeOp
    {
    }
}