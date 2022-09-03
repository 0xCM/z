//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a structure whose values are nonnegative
    /// </summary>
    /// <typeparam name="S">The reifying structure</typeparam>
    public interface INonNegative<S>
        where S : INonNegative<S>, new()
    {

    }
}