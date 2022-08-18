//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a reversible structure
    /// </summary>
    /// <typeparam name="S">The structure type</typeparam>
    [Free]
    public interface IReversible<F,T>
        where F : IReversible<F,T>, new()
    {
        F Reverse();
    }
}