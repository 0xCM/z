//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes free monoidal operations
    /// </summary>
    /// <typeparam name="T">The individual type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Free_monoid</remarks>
    [Free]
    public interface IFreeMonoid<T> : IMonoid<T>, IConcatenable<T>, ICounted, INullity
    {

    }
}