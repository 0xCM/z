//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a distribution specifier
    /// </summary>
    [Free]
    public interface IDistributionSpec
    {
        DistributionKind DistKind {get;}
    }

    /// <summary>
    /// Characterizes a T-parametric distribution specifier
    /// </summary>
    /// <typeparam name="T">The sample value type</typeparam>
    [Free]
    public interface IDistributionSpec<T> : IDistributionSpec
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a T-parametric distribution specifier reification
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="T">The sample value type</typeparam>
    [Free]
    public interface IDistributionSpec<F,T> : IDistributionSpec<T>
        where T : unmanaged
        where F : unmanaged, IDistributionSpec<F,T>
    {

    }
}