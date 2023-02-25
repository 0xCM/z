//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRng
    {
        Label Name => RP.Empty;
    }

    [Free]
    public interface IRng<T> : IRng, ISource<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IRngAdapter : IRng
    {
        IRng Source {get;}

        Label IRng.Name
            => Source.Name;
    }
}