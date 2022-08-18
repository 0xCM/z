//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an adapter
    /// </summary>
    /// <typeparam name="S">The adapted subject type</typeparam>
    public interface IAdapter<S>
    {
        S Subject {get;}
    }

    /// <summary>
    /// Characterizes a <see cref='IAdapter{S}'/> reification
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    /// <typeparam name="S">The subject</typeparam>
    public interface IAdapter<H,S> : IAdapter<S>
        where H : IAdapter<H,S>
    {
        H Adapt(S subject);
    }
}