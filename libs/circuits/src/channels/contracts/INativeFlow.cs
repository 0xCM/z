//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeFlow : ITextual
    {
        INativeChannel Source {get;}

        INativeChannel Target {get;}
    }

    [Free]
    public interface INativeFlow<S,T> : INativeFlow
        where S : INativeChannel
        where T : INativeChannel
    {
        new S Source {get;}

        new T Target {get;}

        INativeChannel INativeFlow.Source
            => Source;

        INativeChannel INativeFlow.Target
            => Target;
    }

    [Free]
    public interface INativeFlow<K,S,T> : INativeFlow<S,T>
        where K : unmanaged
        where S : INativeChannel
        where T : INativeChannel
    {

    }
}