//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRuntimeObject : IClrArtifact
    {

    }

    [Free]
    public interface IRuntimeObject<D> : IRuntimeObject
    {
        D Definition {get;}
    }

    [Free]
    public interface IRuntimeObject<H,D> : IRuntimeObject<D>
        where H : IRuntimeObject<H,D>
    {

    }
}