//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes structural reifications of Currency
    /// </summary>
    /// <typeparam name="S">The structural reification type</typeparam>
    public interface ICurrency<S> : IBoundReal<S>, IFractional<S>
        where S : ICurrency<S>, new()
    {

    }
}