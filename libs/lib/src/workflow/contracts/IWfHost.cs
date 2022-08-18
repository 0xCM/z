//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfHost
    {
        Type Type {get;}

        string Name => Type.Name;
    }

    public interface IWfHost<H> : IWfHost
        where H : IWfHost<H>, new()
    {
        Type IWfHost.Type
            => typeof(H);
    }

    public interface IWfHost<H,S> : IWfHost<H>
        where H : IWfHost<H,S>, new()
    {

    }

    public interface IWfHost<H,S,T> : IWfHost<H,S>
        where H : IWfHost<H,S,T>, new()
    {

    }
}