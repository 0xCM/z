//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeModule : IDisposable
    {
        string Name {get;}

        IntPtr Handle {get;}

        bool Owner {get;}
    }

    [Free]
    public interface INativeModule<T> : INativeModule
        where T : unmanaged
    {

    }
}